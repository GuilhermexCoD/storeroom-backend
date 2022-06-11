using System.Threading.Tasks;
using Storeroom.Application.Dtos;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        Task<ProductDto[]> GetAllProductsByNameAsync(string name);
        Task<ProductDto[]> GetProductsByBarcodeAsync(string barcode);
    }
}