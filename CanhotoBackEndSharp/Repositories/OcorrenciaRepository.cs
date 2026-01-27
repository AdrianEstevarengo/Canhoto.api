using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CanhotoBackEndSharp.Data;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly ApplicationDbContext _db;
        public OcorrenciaRepository(ApplicationDbContext db) => _db = db;

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            await _db.Ocorrencias.AddAsync(ocorrencia);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ocorrencia>> GetByEntregaIdAsync(int entregaId)
        {
            return await _db.Ocorrencias.Where(o => o.EntregaId == entregaId).ToListAsync();
        }
    }
}