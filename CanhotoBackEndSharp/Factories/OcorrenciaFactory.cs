using System;
using System.Collections.Generic;
using System.Linq;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Dtos;

namespace CanhotoBackEndSharp.Factories
{
    public static class OcorrenciaFactory
    {
        public static OcorrenciaDto ToDto(Ocorrencia o)
        {
            if (o == null) return null!;

            return new OcorrenciaDto
            {
                Id = o.Id,
                Descricao = o.Descricao,
                Data = o.Data,
                Tipo = o.Tipo.ToString(),
                EntregaId = o.EntregaId
            };
        }

        public static Ocorrencia ToEntity(OcorrenciaDto dto)
        {
            if (dto == null) return null!;

            return new Ocorrencia
            {
                Id = dto.Id,
                Descricao = dto.Descricao,
                Data = dto.Data,
                Tipo = Enum.TryParse<TipoOcorrencia>(dto.Tipo, out var t) ? t : TipoOcorrencia.Informacao,
                EntregaId = dto.EntregaId
            };
        }

        public static List<OcorrenciaDto> ToDtoList(IEnumerable<Ocorrencia> list)
        {
            return list?.Select(ToDto).ToList() ?? new List<OcorrenciaDto>();
        }
    }
}
