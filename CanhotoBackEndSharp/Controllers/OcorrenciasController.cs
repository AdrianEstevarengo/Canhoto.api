using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CanhotoBackEndSharp.Services;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Dtos;
using CanhotoBackEndSharp.Factories;

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
            var dto = CanhotoBackEndSharp.Factories.OcorrenciaFactory.ToDtoList(list);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OcorrenciaDto ocorrenciaDto)
        {
            var ocorrencia = new CanhotoBackEndSharp.Models.Ocorrencia
            {
                Descricao = ocorrenciaDto.Descricao,
                Data = ocorrenciaDto.Data,
                Tipo = Enum.TryParse<CanhotoBackEndSharp.Models.TipoOcorrencia>(ocorrenciaDto.Tipo, out var t) ? t : CanhotoBackEndSharp.Models.TipoOcorrencia.Informacao,
                EntregaId = ocorrenciaDto.EntregaId
            };

            await _service.AddAsync(ocorrencia);

            ocorrenciaDto.Id = ocorrencia.Id;
            return CreatedAtAction(nameof(GetByEntrega), new { entregaId = ocorrenciaDto.EntregaId }, ocorrenciaDto);
        }
    }
}