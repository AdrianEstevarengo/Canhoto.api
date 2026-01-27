using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Data;
using Microsoft.EntityFrameworkCore;

namespace CanhotoBackEndSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db) => _db = db;

        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            var totalEntregas = await _db.Entregas.CountAsync();
            var entregues = await _db.Entregas.CountAsync(e => e.Status == Models.StatusEntrega.Entregue);
            var pendentes = await _db.Entregas.CountAsync(e => e.Status == Models.StatusEntrega.Pendente);

            return Ok(new { totalEntregas, entregues, pendentes });
        }
    }
}