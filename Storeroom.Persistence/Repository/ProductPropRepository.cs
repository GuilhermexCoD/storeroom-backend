using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class ProductPropRepository : RepositoryBase<ProductProp>, IProductPropRepository
    {

        public ProductPropRepository(StoreroomContext context) : base(context)
        {
            _dataBase = _context.ProductProps;
        }

        public override void CommumDataBaseOperations(bool asNoTracking = true)
        {
            base.CommumDataBaseOperations(asNoTracking);
            
            IQueryable<ProductProp> query = _dataBase
                .Include(pp => pp.Products);

            _dataBase = query.OrderBy(pp => pp.Name);
        }

        public async Task<ProductProp[]> GetAllProductPropsByNameAsync(string name)
        {
            CommumDataBaseOperations();
            
            _dataBase.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await _dataBase.ToArrayAsync();
        }

        public async Task<ProductProp[]> GetProductPropsByBarcodeAsync(string barcode)
        {
            CommumDataBaseOperations();

            _dataBase.Where(p => p.Barcode.Contains(barcode.ToLower()));

            return await _dataBase.ToArrayAsync();
        }
    }
}