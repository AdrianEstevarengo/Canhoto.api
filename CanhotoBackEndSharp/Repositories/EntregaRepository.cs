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

        public async Task AddCanhotoAsync(Canhoto canhoto)
        {
            await _db.Canhotos.AddAsync(canhoto);
            await _db.SaveChangesAsync();
        }

        public async Task<int> CountEntregasHojeAsync()
        {
            var today = DateTime.Today;
            return await _db.Entregas.CountAsync(e => e.DataPrevisao.Date == today);
        }

        public async Task<int> CountEntregasPendentesAsync()
        {
            return await _db.Entregas.CountAsync(e => e.Status == StatusEntrega.Pendente);
        }

        public async Task<int> CountEntregasAtrasadasAsync()
        {
            var today = DateTime.Today;
            return await _db.Entregas.CountAsync(e => e.DataPrevisao.Date < today && e.Canhoto == null && e.Status != StatusEntrega.Cancelada);
        }

        public async Task<int> CountEntregasEntreguesHojeAsync()
        {
            var today = DateTime.Today;
            return await _db.Canhotos.CountAsync(c => c.DataAssinatura.Date == today);
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