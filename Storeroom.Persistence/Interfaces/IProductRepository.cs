using System;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product[]> GetAllProductsByNameAsync(string name);
        Task<Product[]> GetProductsByBarcodeAsync(string barcode);
    }
}