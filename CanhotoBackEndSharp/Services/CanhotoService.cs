using System.Threading.Tasks;
using CanhotoBackEndSharp.Dtos;
using CanhotoBackEndSharp.Repositories;
using CanhotoBackEndSharp.Models;
using CanhotoBackEndSharp.Factories;

namespace CanhotoBackEndSharp.Services
{
    public class CanhotoService : ICanhotoService
    {
        private readonly IEntregaRepository _entregaRepo;
        public CanhotoService(IEntregaRepository entregaRepo) => _entregaRepo = entregaRepo;

        public async Task<CanhotoDto> AddAsync(CanhotoDto canhotoDto)
        {
            // Validate entrega exists
            var entrega = await _entregaRepo.GetByIdAsync(canhotoDto.EntregaId);
            if (entrega == null) throw new KeyNotFoundException("Entrega not found");

            // Ensure only one canhoto
            if (entrega.Canhoto != null) throw new System.InvalidOperationException("Entrega already has canhoto");

            var canhoto = CanhotoFactory.ToEntity(canhotoDto);

            // Persist canhoto via repository
            await _entregaRepo.AddCanhotoAsync(canhoto);

            // Update entrega status to Entregue
            entrega.Canhoto = canhoto;
            entrega.Status = StatusEntrega.Entregue;

            // Save entrega changes
            await _entregaRepo.AddAsync(entrega); // reuse AddAsync to save - repo will add duplicates if not careful

            return CanhotoFactory.ToDto(canhoto);
        }
    }
}
