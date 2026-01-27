using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Repositories;

namespace CanhotoBackEndSharp.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly IEntregaRepository _repo;
        public EntregaService(IEntregaRepository repo) => _repo = repo;

        public async Task AddAsync(Entrega entrega) => await _repo.AddAsync(entrega);

        public async Task<IEnumerable<Entrega>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Entrega?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    }
}