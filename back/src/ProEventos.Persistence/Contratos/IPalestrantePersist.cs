using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        //PALESTRANTE
        Task<Palestrante[]> GerAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GerAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GerAllPalestrantesByIdAsync(int palestranteId, bool includeEventos = false);
    }
}