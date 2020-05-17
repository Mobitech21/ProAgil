using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Dtos;
using ProAgil.Domain;
using AutoMapper;
using ProAgil.Repository.Interface;
using System.Collections.Generic;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository<Evento> _repo;
     
        private readonly IMapper _mapper;
      
        public EventoController(IProAgilRepository<Evento> repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
              var eventos = await _repo.GetAllEventosAsync(true);
              var results  = _mapper.Map<EventoDto[]>(eventos);

              return Ok(results);

           }
           catch (System.Exception ex)
           {
           return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
 
          }
        }


        [HttpGet("{EventId}")]
        public async Task<IActionResult> Get(int EventId)
        {
           try
           {
              var results = await _repo.GetAllEventosAsyncById(EventId,true);
                return Ok(results);

           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");

          }
        }


        [HttpGet("getByTema/{EventId}")]
        public async Task<IActionResult> Get(string tema)
        {
           try
           {
              var results = await _repo.GetAllEventosAsyncByTema(tema,true);
                return Ok(results);

           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");

          }
        }



        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
           try
           {
                var evento = _mapper.Map<Evento>(model);

                _repo.Add(evento);

                if(await _repo.SaveChangeAsync())
                {
                     return Created($"/api/evento/{model.id}",model);

                }


           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");

          }

          return  BadRequest();
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId ,Evento model)
        {
           try
           {       

                var evento = await _repo.GetAllEventosAsyncById(eventoId,false);
               
                if(evento == null) return NotFound();


                //var eventoNew = _mapper.Map<Evento>(model);

                // var mapes =  _mapper.Map(model,evento);

                _repo.Update(evento);

                if(await _repo.SaveChangeAsync())
                {
                     return Created($"/api/evento/{model.id}",model);

                }


           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");

          }

          return  BadRequest();
        }


        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId )
        {
           try
           {
                var evento = await _repo.GetAllEventosAsyncById(eventoId,false);
                if(evento == null) return NotFound();

                _repo.Delete(evento);
                if(await _repo.SaveChangeAsync())
                {
                    return Ok();
                }


           }
           catch (System.Exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");

          }

          return  BadRequest();
        }

    }
}