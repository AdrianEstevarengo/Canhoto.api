using System;
using System.Collections.Generic;

namespace CanhotoBackEndSharp.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public string CodigoRastreio { get; set; } = string.Empty;
        public DateTime DataPrevisao { get; set; }
        public StatusEntrega Status { get; set; }
        public Prioridade Prioridade { get; set; }

        // Relationships
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public Canhoto? Canhoto { get; set; }

        public ICollection<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    }
}