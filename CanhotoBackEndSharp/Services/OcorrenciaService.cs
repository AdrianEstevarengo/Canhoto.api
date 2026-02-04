using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Repositories;
using CanhotoBackEndSharp.Dtos;
using CanhotoBackEndSharp.Factories;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _repo;
        public OcorrenciaService(IOcorrenciaRepository repo) => _repo = repo;

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            // Basic validation: entrega exists is responsibility of caller or repo; repository will fail if FK invalid.
            await _repo.AddAsync(ocorrencia);

            // Minimal rule: if ocorrencia is Avaria, create an action (caller/service orchestration could handle it). For now, leave to future.
        }

        public async Task<IEnumerable<Ocorrencia>> GetByEntregaIdAsync(int entregaId) => await _repo.GetByEntregaIdAsync(entregaId);
    }
}