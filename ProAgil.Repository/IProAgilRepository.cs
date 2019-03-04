using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangeAsync();

         //EVENTOS
         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
         Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);

        //PALESTRANTE
         Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false);
         Task<Palestrante[]> GetAllPalestranteAsyncByName(string Nome, bool includeEventos);
         Task<Palestrante> GetAllPalestranteAsync(int PalestranteId, bool includeEventos);

    }
}