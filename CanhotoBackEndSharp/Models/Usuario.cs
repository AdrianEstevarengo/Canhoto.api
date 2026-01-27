using System.Collections.Generic;

namespace CanhotoBackEndSharp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public PerfilUsuario Perfil { get; set; }

        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Acao> Acoes { get; set; } = new List<Acao>();
    }
}