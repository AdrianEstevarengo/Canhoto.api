using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CanhotoBackEndSharp.Data;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly ApplicationDbContext _db;
        public EntregaRepository(ApplicationDbContext db) => _db = db;

        public async Task AddAsync(Entrega entrega)
        {
            await _db.Entregas.AddAsync(entrega);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entrega>> GetAllAsync()
        {
            return await _db.Entregas.Include(e => e.Canhoto).Include(e => e.Ocorrencias).ToListAsync();
        }

        public async Task<Entrega?> GetByIdAsync(int id)
        {
            return await _db.Entregas.Include(e => e.Canhoto).Include(e => e.Ocorrencias).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}