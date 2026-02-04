using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CanhotoBackEndSharp.Services;

namespace CanhotoBackEndSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;
        public DashboardController(DashboardService service) => _service = service;

        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            var dto = await _service.GetSummaryAsync();
            return Ok(dto);
        }

        [HttpGet("feed")]
        public async Task<IActionResult> Feed()
        {
            var feed = await _service.GetFeedAsync();
            return Ok(feed);
        }
    }
}
