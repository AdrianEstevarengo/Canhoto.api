using System.Collections.Generic;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Services
{
    public interface IEntregaService
    {
        Task<IEnumerable<Entrega>> GetAllAsync();
        Task<Entrega?> GetByIdAsync(int id);
        Task AddAsync(Entrega entrega);
    }
}