using System;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IProductPropRepository : IRepository<ProductProp>
    {
        Task<ProductProp[]> GetAllProductPropsByNameAsync(string name);
        Task<ProductProp[]> GetProductPropsByBarcodeAsync(string barcode);
    }
}