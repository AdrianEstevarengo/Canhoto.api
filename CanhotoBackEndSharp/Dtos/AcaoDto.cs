using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class AcaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public string? Observacao { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
