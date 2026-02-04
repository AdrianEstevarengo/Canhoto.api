using System;
using System.Collections.Generic;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Dtos
{
    public class EntregaDto
    {
        public int Id { get; set; }
        public string CodigoRastreio { get; set; } = string.Empty;
        public DateTime DataPrevisao { get; set; }
        public StatusEntrega Status { get; set; }
        public Prioridade Prioridade { get; set; }

        public int? UsuarioId { get; set; }

        public CanhotoDto? Canhoto { get; set; }

        public List<OcorrenciaDto> Ocorrencias { get; set; } = new List<OcorrenciaDto>();
        public List<AcaoDto> Acoes { get; set; } = new List<AcaoDto>();
        public SlaInfoDto? SlaInfo { get; set; }
    }
}
