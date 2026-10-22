using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Services;
using CanhotoBackEndSharp.Dtos;

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
            var dtoList = CanhotoBackEndSharp.Factories.EntregaFactory.ToDtoList(list);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            var dto = CanhotoBackEndSharp.Factories.EntregaFactory.ToDto(item);
            return Ok(dto);
        }
    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EntregaDto entregaDto)
        {
            var entity = CanhotoBackEndSharp.Factories.EntregaFactory.ToEntity(entregaDto);
            await _service.AddAsync(entity);
            var dto = CanhotoBackEndSharp.Factories.EntregaFactory.ToDto(entity);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
    }
}