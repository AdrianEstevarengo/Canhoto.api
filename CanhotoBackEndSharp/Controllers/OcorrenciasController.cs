using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Services;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciasController : ControllerBase
    {
        private readonly IOcorrenciaService _service;
        public OcorrenciasController(IOcorrenciaService service) => _service = service;

        [HttpGet("by-entrega/{entregaId}")]
        public async Task<IActionResult> GetByEntrega(int entregaId)
        {
            var list = await _service.GetByEntregaIdAsync(entregaId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ocorrencia ocorrencia)
        {
            await _service.AddAsync(ocorrencia);
            return CreatedAtAction(nameof(GetByEntrega), new { entregaId = ocorrencia.EntregaId }, ocorrencia);
        }
    }
}