using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class ProductStatusRepository : RepositoryBase<ProductStatus>, IProductStatusRepository
    {

        public ProductStatusRepository(StoreroomContext context) : base(context)
        {
            _dataBase = _context.ProductStatuses;
        }

        public override void CommumDataBaseOperations(bool asNoTracking = true)
        {
            base.CommumDataBaseOperations(asNoTracking);

            IQueryable<ProductStatus> query = _dataBase
                        .Include(ps => ps.Products);

            _dataBase = query.OrderBy(ps => ps.Type);

        }

        public async Task<ProductStatus[]> GetAllProductStatusByTypeAsync(string type)
        {
            CommumDataBaseOperations();

            _dataBase = _dataBase.Where(p => p.Type.ToLower().Contains(type.ToLower()));

            return await _dataBase.ToArrayAsync();
        }
    }
}