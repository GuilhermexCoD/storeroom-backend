using System;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User[]> GetAllUsersByNameAsync(string name);
        Task<User[]> GetAllUsersByFamilyIdAsync(Guid id);
        Task<User[]> GetAllUsersByFamilyNameAsync(string name);
    }
}