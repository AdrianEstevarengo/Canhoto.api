using System.Collections.Generic;
using System.Linq;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Dtos;

namespace CanhotoBackEndSharp.Factories
{
    public static class AcaoFactory
    {
        public static AcaoDto ToDto(Acao a)
        {
            if (a == null) return null!;
            return new AcaoDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Data = a.Data,
                UsuarioId = a.UsuarioId,
                Observacao = a.Observacao,
                Status = a.Status
            };
        }

        public static List<AcaoDto> ToDtoList(IEnumerable<Acao> list) => list?.Select(ToDto).ToList() ?? new List<AcaoDto>();
    }
}
