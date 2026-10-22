using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class FeedItemDto
    {
        public string Tipo { get; set; } = string.Empty; // e.g., "Ocorrencia", "Acao", "Canhoto"
        public int ReferenciaId { get; set; }
        public string Resumo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
    }
}
