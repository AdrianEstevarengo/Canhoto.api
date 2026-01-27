using System;

namespace CanhotoBackEndSharp.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public TipoOcorrencia Tipo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        // Relationship
        public int EntregaId { get; set; }
        public Entrega? Entrega { get; set; }
    }
}