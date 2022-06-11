using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {

        public FamilyRepository(StoreroomContext context) : base(context)
        {
            _dataBase = _context.Families;
            
        }

        public override void CommumDataBaseOperations(bool asNoTracking = true)
        {
            base.CommumDataBaseOperations(asNoTracking);

            IQueryable<Family> query = _dataBase
                .Include(f => f.Users)
                .Include(f => f.Manager);

            _dataBase = query.AsNoTracking().OrderBy(f => f.Name);
        }

        public async Task<Family[]> GetAllFamiliesByNameAsync(string name)
        {
            CommumDataBaseOperations();

            _dataBase.OrderBy(f => f.Name).Where(f => f.Name.ToLower().Contains(name.ToLower()));

            return await _dataBase.ToArrayAsync();
        }
    }
}