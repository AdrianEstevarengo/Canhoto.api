using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class OcorrenciaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int EntregaId { get; set; }
    }
}
