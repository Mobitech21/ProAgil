using System;
using System.Threading.Tasks;
using ProAgil.Repository.Interface;
using ProAgil.Respository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository<TEntity> : IProAgilRepository<TEntity> , 
    IDisposable where TEntity : class
   {
       private readonly ProAgilContext _context; 
       public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
           // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add(TEntity T)
        {
           // _context.Set<TEntity>().Add(T);
           _context.Add(T);
        }
        public void Delete(TEntity T)
        {
          _context.Remove(T);
        }
        public void Dispose() 
        {
             if (_context != null)
            {
                _context.Dispose();
            }
                GC.SuppressFinalize(this);
            
        }
        public Task<TEntity> Getbyid(int id)
        {
              return _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> Getll()
        {
             return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<bool> SaveChangeAsync()
        {
          return  (await  _context.SaveChangesAsync()) > 0 ;
        }
        public void Update(TEntity T)
        {
            _context.Update(T);
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
              IQueryable<Evento> query = _context.Eventos
                 .Include(c=> c.Lotes)
                 .Include(c=> c.RedesSociais);

                 if(includePalestrantes)
                 {
                    query = query
                    .Include(p=> p.PalestranteEventos)
                    .ThenInclude(pa => pa.Palestrante);
                 }

              query = query.AsNoTracking().OrderByDescending(c=> c.DataEvento);
              return await query.ToArrayAsync();
          
        }
         public async Task<Evento[]> GetAllEventosAsyncByTema(string tema,bool includePalestrantes = false)
        {
              IQueryable<Evento> query = _context.Eventos
                 .Include(c=> c.Lotes)
                 .Include(c=> c.RedesSociais);

                 if(includePalestrantes)
                 {
                    query = query
                    .Include(p=> p.PalestranteEventos)
                    .ThenInclude(pa => pa.Palestrante);
                 }

              query = query.AsNoTracking().OrderByDescending(c=> c.DataEvento)
                   .Where(c=> c.Tema.ToLower().Contains(tema.ToLower()));
              return await query.ToArrayAsync();
          
        }
         public async Task<Evento> GetAllEventosAsyncById(int EventoId,bool includePalestrantes = false)
        {
              IQueryable<Evento> query = _context.Eventos
                 .Include(c=> c.Lotes)
                 .Include(c=> c.RedesSociais);

                 if(includePalestrantes)
                 {
                    query = query
                    .Include(p=> p.PalestranteEventos)
                    .ThenInclude(pa => pa.Palestrante);
                 }

              query = query.AsNoTracking().OrderByDescending(c=> c.DataEvento)
                   .Where(c=> c.id == EventoId);
              return await query.FirstOrDefaultAsync();
          
        }
         public async Task<Palestrante> GetAllPalestranteAsync(int PalestranteId,bool includeEventos = false)
        {
              IQueryable<Palestrante> query = _context.Palestrantes
                 .Include(c=> c.RedesSociais);
               

                 if(includeEventos)
                 {
                    query = query
                    .Include(p=> p.PalestranteEventos)
                    .ThenInclude(e => e.Eventos);
                 }

              query = query.AsNoTracking().OrderBy(c=> c.Nome)
                   .Where(c=> c.id == PalestranteId);
              return await query.FirstOrDefaultAsync();
          
        }
         public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string nome ,bool includeEventos = false)
        {
              IQueryable<Palestrante> query = _context.Palestrantes
                 .Include(c=> c.RedesSociais);
               

                 if(includeEventos)
                 {
                    query = query
                    .Include(p=> p.PalestranteEventos)
                    .ThenInclude(e => e.Eventos);
                 }

              query = query.AsNoTracking().OrderBy(c=> c.Nome)
                   .Where(c=> c.Nome.ToLower().Contains(nome.ToLower()));
         
              return await query.ToArrayAsync();
          
        }
   
    }
   }