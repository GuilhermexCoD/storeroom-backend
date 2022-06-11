using System.Threading.Tasks;
using Storeroom.Application.Dtos;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IProductStatusService : IService<ProductStatusDto>
    {
        Task<ProductStatusDto[]> GetAllProductStatusByTypeAsync(string type);
    }
}