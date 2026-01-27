using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Repositories;

namespace CanhotoBackEndSharp.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _repo;
        public OcorrenciaService(IOcorrenciaRepository repo) => _repo = repo;

        public async Task AddAsync(Ocorrencia ocorrencia) => await _repo.AddAsync(ocorrencia);

        public async Task<IEnumerable<Ocorrencia>> GetByEntregaIdAsync(int entregaId) => await _repo.GetByEntregaIdAsync(entregaId);
    }
}