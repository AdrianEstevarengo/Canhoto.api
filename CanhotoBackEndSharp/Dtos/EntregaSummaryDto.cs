using System;
using CanhotoBackEndSharp.Models;

namespace CanhotoBackEndSharp.Dtos
{
    public class EntregaSummaryDto
    {
        public int Id { get; set; }
        public string CodigoRastreio { get; set; } = string.Empty;
        public DateTime DataPrevisao { get; set; }
        public StatusEntrega Status { get; set; }
        public Prioridade Prioridade { get; set; }
        public int? UsuarioId { get; set; }
        public bool HasCanhoto { get; set; }
        public string? LastOcorrenciaResumo { get; set; }
    }
}
