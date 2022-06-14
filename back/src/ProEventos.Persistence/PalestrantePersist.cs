using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosDataContext _context;
        public PalestrantePersist(ProEventosDataContext context)
        {
            _context = context;

        }
        public async Task<Palestrante[]> GerAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(pe => pe.redesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.palestranteEvento)
                .ThenInclude(pe => pe.evento);
            }

            query = query.AsNoTracking().OrderBy(pe => pe.id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GerAllPalestrantesByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(pe => pe.redesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.palestranteEvento)
                .ThenInclude(pe => pe.evento);
            }
            query = query.AsNoTracking().OrderBy(pe => pe.id).Where(pe => pe.id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GerAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(pe => pe.redesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.palestranteEvento)
                .ThenInclude(pe => pe.evento);
            }
            query = query.AsNoTracking().OrderBy(pe => pe.id).Where(pe => pe.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}