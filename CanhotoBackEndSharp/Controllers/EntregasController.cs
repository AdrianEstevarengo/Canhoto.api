using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Services;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregasController : ControllerBase
    {
        private readonly IEntregaService _service;
        public EntregasController(IEntregaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Entrega entrega)
        {
            await _service.AddAsync(entrega);
            return CreatedAtAction(nameof(Get), new { id = entrega.Id }, entrega);
        }
    }
}