using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Persistence.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected readonly StoreroomContext _context;
        protected IQueryable<T> _dataBase;

        public RepositoryBase(StoreroomContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(T[] entities)
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            CommumDataBaseOperations();

            return await _dataBase.FirstOrDefaultAsync(i => i.Id == id);
        }

        public virtual async Task<T[]> GetAll()
        {
            CommumDataBaseOperations();

            return await _dataBase.ToArrayAsync();
        }

        public virtual void CommumDataBaseOperations(bool asNoTracking = true)
        {
            if(asNoTracking)
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            else
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

        }
    }
}