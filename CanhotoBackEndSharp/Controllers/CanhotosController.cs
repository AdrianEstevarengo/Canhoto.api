using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Services;
using CanhotoBackEndSharp.Dtos;

namespace CanhotoBackEndSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanhotosController : ControllerBase
    {
        private readonly ICanhotoService _service;
        public CanhotosController(ICanhotoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CanhotoDto canhotoDto)
        {
            var dto = await _service.AddAsync(canhotoDto);
            return CreatedAtAction(null, null, dto);
        }
    }
}
