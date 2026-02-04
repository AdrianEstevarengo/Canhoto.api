using System.Threading.Tasks;
using CanhotoBackEndSharp.Dtos;
using CanhotoBackEndSharp.Repositories;
using System.Collections.Generic;
using CanhotoBackEndSharp.Factories;

namespace CanhotoBackEndSharp.Services
{
    public class DashboardService
    {
        private readonly IEntregaRepository _entregaRepo;
        private readonly IOcorrenciaRepository _ocorrenciaRepo;

        public DashboardService(IEntregaRepository entregaRepo, IOcorrenciaRepository ocorrenciaRepo)
        {
            _entregaRepo = entregaRepo;
            _ocorrenciaRepo = ocorrenciaRepo;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync()
        {
            var totalHoje = await _entregaRepo.CountEntregasHojeAsync();
            var pendentes = await _entregaRepo.CountEntregasPendentesAsync();
            var atrasadas = await _entregaRepo.CountEntregasAtrasadasAsync();
            var entreguesHoje = await _entregaRepo.CountEntregasEntreguesHojeAsync();

            var taxaOnTime = totalHoje == 0 ? 0 : (double)(entreguesHoje * 100) / totalHoje;

            return new DashboardSummaryDto
            {
                TotalEntregasHoje = totalHoje,
                EntregasPendentes = pendentes,
                EntregasAtrasadas = atrasadas,
                EntregasEntreguesHoje = entreguesHoje,
                TaxaOnTime = taxaOnTime,
                SlaViolationsCount = 0 // placeholder; could be derived from queries
            };
        }

        public async Task<IEnumerable<FeedItemDto>> GetFeedAsync()
        {
            // Very simple feed: recent ocorrencias
            var ocorrencias = await _ocorrenciaRepo.GetByEntregaIdAsync(0); // not ideal; modify repo for recent globally if needed
            return OcorrenciaFactory.ToFeedItems(ocorrencias);
        }
    }
}
