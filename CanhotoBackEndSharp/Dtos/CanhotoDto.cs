using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class CanhotoDto
    {
        public int Id { get; set; }
        public DateTime DataAssinatura { get; set; }
        public string Assinante { get; set; } = string.Empty;
        public int EntregaId { get; set; }
    }
}
