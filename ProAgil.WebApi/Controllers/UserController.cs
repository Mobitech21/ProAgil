using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProAgil.Domain.Entidades;
using ProAgil.WebApi.Dtos;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public UserController(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper)
        {
            _configuration = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            

        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {

            return  Ok(new UserDto());
        }
       

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userdto)
        {
            try
            {
                var user = _mapper.Map<User>(userdto);
                var resultado = await _userManager.CreateAsync(user,userdto.Password);
                var userToReturn = _mapper.Map<UserDto>(user);
                if (resultado.Succeeded)
                {
                    return Created("GetUser", userToReturn);
                }

                return BadRequest(resultado.Errors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }
        

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);

               if(result.Succeeded)
                {
                    var appUser = await _userManager.Users.
                        FirstOrDefaultAsync(u => u.NormalizedUserName == userLoginDto.UserName.ToUpper());

                    var usertoReturn = _mapper.Map<UserLoginDto>(appUser);


                    return Ok(new {
                        Token = GenerateJwToken(appUser).Result,
                        User = usertoReturn
                    });
                }

                return Unauthorized();

            }

            catch (Exception ex)
            {
             return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");

            }

        }

        private async Task<string> GenerateJwToken(User appUser)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, User.Identity.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };

            var roles = await _userManager.GetRolesAsync(appUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                 Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value)); ;

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };

            var tokenHandler =  new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }
    }
}