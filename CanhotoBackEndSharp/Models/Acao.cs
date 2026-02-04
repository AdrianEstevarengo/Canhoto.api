using System;

namespace CanhotoBackEndSharp.Models
{
    public class Acao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        // Relationship to Entrega (aggregate)
        public int EntregaId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Status/observacao for action lifecycle
        public string Status { get; set; } = "Pending";
        public string? Observacao { get; set; }
    }
}