using System.Threading.Tasks;
using Storeroom.Application.Dtos;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IProductPropService : IService<ProductPropDto>
    {
        Task<ProductPropDto[]> GetAllProductPropsByNameAsync(string name);
        Task<ProductPropDto[]> GetProductPropsByBarcodeAsync(string barcode);
    }
}