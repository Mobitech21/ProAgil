using System.Collections.Generic;
using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository.Interface
{
    public interface IProAgilRepository<TEntity> where TEntity : class 
    {
         void Add(TEntity T);
         void Update(TEntity T);
         void Delete(TEntity T);
         Task<bool> SaveChangeAsync();
         Task<IEnumerable<TEntity>> Getll();
         Task <TEntity> Getbyid( int id);
         Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome ,bool includeEventos = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsyncByTema(string tema,bool includePalestrantes = false);
         Task<Evento> GetAllEventosAsyncById(int EventoId,bool includePalestrantes = false);
         Task<Palestrante> GetAllPalestranteAsync(int PalestranteId,bool includeEventos = false);
       
    }
}