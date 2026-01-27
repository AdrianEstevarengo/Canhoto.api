using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Repositories
{
    public interface IEntregaRepository
    {
        Task<IEnumerable<Entrega>> GetAllAsync();
        Task<Entrega?> GetByIdAsync(int id);
        Task AddAsync(Entrega entrega);
    }
}