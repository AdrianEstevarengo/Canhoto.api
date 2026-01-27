using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Services
{
    public interface IOcorrenciaService
    {
        Task<IEnumerable<Ocorrencia>> GetByEntregaIdAsync(int entregaId);
        Task AddAsync(Ocorrencia ocorrencia);
    }
}