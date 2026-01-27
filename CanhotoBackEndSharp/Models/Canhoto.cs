using System;

namespace CanhotoBackEndSharp.Models
{
    public class Canhoto
    {
        public int Id { get; set; }
        public DateTime DataAssinatura { get; set; }
        public string Assinante { get; set; } = string.Empty;

        // Relationship
        public int EntregaId { get; set; }
        public Entrega? Entrega { get; set; }
    }
}