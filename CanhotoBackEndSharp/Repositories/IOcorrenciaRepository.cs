using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Repositories
{
    public interface IOcorrenciaRepository
    {
        Task<IEnumerable<Ocorrencia>> GetByEntregaIdAsync(int entregaId);
        Task AddAsync(Ocorrencia ocorrencia);
    }
}