using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosDataContext _context;
        public EventoPersist(ProEventosDataContext context)
        {
            _context = context;

        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.lotes)
            .Include(e => e.redesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.palestranteEvento)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
             .Include(e => e.lotes)
             .Include(e => e.redesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.palestranteEvento)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.id).Where(e => e.id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.lotes)
            .Include(e => e.redesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.palestranteEvento)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.id).Where(e => e.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}