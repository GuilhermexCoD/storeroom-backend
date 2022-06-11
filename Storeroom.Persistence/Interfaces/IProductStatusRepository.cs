using System;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IProductStatusRepository : IRepository<ProductStatus>
    {
        Task<ProductStatus[]> GetAllProductStatusByTypeAsync(string type);
    }
}