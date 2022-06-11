using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);
        
        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(T[] entities);

        void CommumDataBaseOperations(bool asNoTracking = true);

        Task<T> GetByIdAsync(Guid id);

        Task<T[]> GetAll();
        
        Task<bool> SaveChangesAsync();
    }
}