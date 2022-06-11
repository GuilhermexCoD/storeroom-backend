using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(StoreroomContext context) : base(context)
        {
            _dataBase = _context.Users;
        }

        public override void CommumDataBaseOperations(bool asNoTracking = true)
        {
            base.CommumDataBaseOperations(asNoTracking);

            IQueryable<User> query = _dataBase
                .Include(u => u.Family)
                .Include(u => u.OwnFamily);

            _dataBase = query.OrderBy(u => u.FullName);
        }

        public async Task<User[]> GetAllUsersByFamilyIdAsync(Guid id)
        {
            CommumDataBaseOperations();

            _dataBase = _dataBase.OrderBy(u => u.CreatedAt).Where(u => u.FamilyId == id);

            return await _dataBase.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByFamilyNameAsync(string name)
        {
            CommumDataBaseOperations();

            _dataBase = _dataBase.OrderBy(u => u.CreatedAt).Where(u => u.Family.Name.ToLower().Contains(name.ToLower()));

            return await _dataBase.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByNameAsync(string name)
        {
            CommumDataBaseOperations();

            _dataBase = _dataBase.OrderBy(u => u.CreatedAt).Where(u => u.FullName.ToLower().Contains(name.ToLower()));

            return await _dataBase.ToArrayAsync();
        }
    }
}