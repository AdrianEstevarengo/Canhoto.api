using System.Threading.Tasks;
using CanhotoBackEndSharp.Dtos;

namespace CanhotoBackEndSharp.Services
{
    public interface ICanhotoService
    {
        Task<CanhotoDto> AddAsync(CanhotoDto canhotoDto);
    }
}
