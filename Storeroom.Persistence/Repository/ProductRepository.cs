using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(StoreroomContext context) : base(context)
        {
            _dataBase = _context.Products;
        }

        public override void CommumDataBaseOperations(bool asNoTracking = true)
        {
            base.CommumDataBaseOperations(asNoTracking);

            IQueryable<Product> query = _dataBase
                .Include(p => p.ProductProp)
                .Include(p => p.ProductStatus)
                .Include(p => p.Family);

            _dataBase = query.OrderBy(p => p.ExpireAt);
        }

        public async Task<Product[]> GetProductsByBarcodeAsync(string barcode)
        {
            CommumDataBaseOperations();

            _dataBase.Where(p => p.ProductProp.Barcode.Contains(barcode.ToLower()));

            return await _dataBase.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByNameAsync(string name)
        {
            CommumDataBaseOperations();

            _dataBase.Where(p => p.ProductProp.Name.ToLower().Contains(name.ToLower()));

            return await _dataBase.ToArrayAsync();
        }
    }
}