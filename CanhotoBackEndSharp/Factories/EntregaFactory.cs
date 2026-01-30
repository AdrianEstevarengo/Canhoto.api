using System.Linq;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Dtos;
using System.Collections.Generic;

namespace CanhotoBackEndSharp.Factories
{
    public static class EntregaFactory
    {
        public static EntregaDto ToDto(Entrega e)
        {
            if (e == null) return null!;

            return new EntregaDto
            {
                Id = e.Id,
                CodigoRastreio = e.CodigoRastreio,
                DataPrevisao = e.DataPrevisao,
                Status = e.Status,
                Prioridade = e.Prioridade,
                UsuarioId = e.UsuarioId,
                Canhoto = e.Canhoto == null ? null : new CanhotoDto
                {
                    Id = e.Canhoto.Id,
                    DataAssinatura = e.Canhoto.DataAssinatura,
                    Assinante = e.Canhoto.Assinante,
                    EntregaId = e.Canhoto.EntregaId
                },
                Ocorrencias = e.Ocorrencias?.Select(o => new OcorrenciaDto
                {
                    Id = o.Id,
                    Descricao = o.Descricao,
                    Data = o.Data,
                    Tipo = o.Tipo.ToString(),
                    EntregaId = o.EntregaId
                }).ToList() ?? new List<OcorrenciaDto>()
            };
        }

        public static Entrega ToEntity(EntregaDto dto)
        {
            if (dto == null) return null!;

            var e = new Entrega
            {
                Id = dto.Id,
                CodigoRastreio = dto.CodigoRastreio,
                DataPrevisao = dto.DataPrevisao,
                Status = dto.Status,
                Prioridade = dto.Prioridade,
                UsuarioId = dto.UsuarioId
            };

            if (dto.Canhoto != null)
            {
                e.Canhoto = new Canhoto
                {
                    Id = dto.Canhoto.Id,
                    DataAssinatura = dto.Canhoto.DataAssinatura,
                    Assinante = dto.Canhoto.Assinante,
                    EntregaId = dto.Canhoto.EntregaId
                };
            }

            if (dto.Ocorrencias != null)
            {
                e.Ocorrencias = dto.Ocorrencias.Select(o => new Ocorrencia
                {
                    Id = o.Id,
                    Descricao = o.Descricao,
                    Data = o.Data,
                    Tipo = Enum.TryParse<TipoOcorrencia>(o.Tipo, out var t) ? t : TipoOcorrencia.Informacao,
                    EntregaId = o.EntregaId
                }).ToList();
            }

            return e;
        }

        public static List<EntregaDto> ToDtoList(IEnumerable<Entrega> entregas)
        {
            return entregas.Select(ToDto).ToList();
        }
    }
}
