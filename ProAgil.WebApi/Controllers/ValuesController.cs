using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Respository;


namespace projetowebapi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProAgilContext _contexto;
        public ValuesController(ProAgilContext  contexto)
        {
            _contexto = contexto;
        }


        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
              var results = await _contexto.Eventos.ToListAsync();
                return Ok("retornou");

           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
                
          }
           
            //   var text = "<div><h1>Digite seu nome</h1></div>"
            //   +"<input type=Text id='idnome'></br>"
            //   +"<hr>"
            //   +"<input type=button value='Click me' onclick=alert(idnome.value);></br>";
            
            //    byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            //    await Response.Body.WriteAsync(data, 0, data.Length);

            // return new Evento[] { 
            //     new Evento(){

            //         EventoId = 1,
            //         Tema = "Angular e WebApi",
            //         Local = "Niteroi",
            //         Lote = "1 lote",
            //         QtdPessoas = 259,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy")
            //     },

            //       new Evento(){

            //         EventoId = 2,
            //         Tema = "Angulareee",
            //         Local = "Sao Paulo",
            //         Lote = "2 lote",
            //         QtdPessoas = 1000,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy")
            //     },
            //  };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
       {
          try
           {
               var results = await _contexto.Eventos.FirstOrDefaultAsync(x=> x.id == id);
                return Ok(results);
            }
           catch (System.Exception)
           {
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
                
          }

            // return new Evento[] { 
            //     new Evento(){

            //         EventoId = 1,
            //         Tema = "Angular e WebApi",
            //         Local = "Niteroi",
            //         Lote = "1 lote",
            //         QtdPessoas = 259,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy")
            //     },

            //       new Evento(){

            //         EventoId = 2,
            //         Tema = "Angulareee",
            //         Local = "Sao Paulo",
            //         Lote = "2 lote",
            //         QtdPessoas = 1000,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy")
            //     },
            //  }.FirstOrDefault(x=> x.EventoId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
