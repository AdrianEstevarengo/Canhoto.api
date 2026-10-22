using System.Collections.Generic;
using System.Linq;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Dtos;

namespace CanhotoBackEndSharp.Factories
{
    public static class CanhotoFactory
    {
        public static CanhotoDto ToDto(Canhoto c)
        {
            if (c == null) return null!;
            return new CanhotoDto
            {
                Id = c.Id,
                DataAssinatura = c.DataAssinatura,
                Assinante = c.Assinante,
                EntregaId = c.EntregaId
            };
        }

        public static Canhoto ToEntity(CanhotoDto dto)
        {
            if (dto == null) return null!;
            return new Canhoto
            {
                Id = dto.Id,
                DataAssinatura = dto.DataAssinatura,
                Assinante = dto.Assinante,
                EntregaId = dto.EntregaId
            };
        }
    }
}
