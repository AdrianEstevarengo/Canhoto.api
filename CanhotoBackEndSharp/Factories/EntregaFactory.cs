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
                }).ToList() ?? new List<OcorrenciaDto>(),
                Acoes = e.Acoes?.Any() == true ? CanhotoBackEndSharp.Factories.AcaoFactory.ToDtoList(e.Acoes) : new List<CanhotoBackEndSharp.Dtos.AcaoDto>(),
                SlaInfo = BuildSlaInfo(e)
            };
        }

        private static SlaInfoDto? BuildSlaInfo(Entrega e)
        {
            if (e == null) return null;

            var sla = new SlaInfoDto();

            if (e.Canhoto != null)
            {
                sla.DataFim = e.Canhoto.DataAssinatura;
                sla.Violated = e.Canhoto.DataAssinatura > e.DataPrevisao;
                sla.DaysLate = sla.Violated ? (int)(e.Canhoto.DataAssinatura.Date - e.DataPrevisao.Date).TotalDays : 0;
            }
            else
            {
                sla.DataFim = null;
                sla.Violated = false;
                sla.DaysLate = 0;
            }

            // DataInicio not tracked; keep null for now
            sla.DataInicio = null;
            return sla;
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

        public static List<EntregaSummaryDto> ToSummaryList(IEnumerable<Entrega> entregas)
        {
            return entregas.Select(e => new EntregaSummaryDto
            {
                Id = e.Id,
                CodigoRastreio = e.CodigoRastreio,
                DataPrevisao = e.DataPrevisao,
                Status = e.Status,
                Prioridade = e.Prioridade,
                UsuarioId = e.UsuarioId,
                HasCanhoto = e.Canhoto != null,
                LastOcorrenciaResumo = e.Ocorrencias?.OrderByDescending(o => o.Data).FirstOrDefault()?.Descricao
            }).ToList();
        }
    }
}
