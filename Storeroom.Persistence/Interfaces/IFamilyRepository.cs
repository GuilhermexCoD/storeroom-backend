using System;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IFamilyRepository : IRepository<Family>
    {
        Task<Family[]> GetAllFamiliesByNameAsync(string name);
    }
}