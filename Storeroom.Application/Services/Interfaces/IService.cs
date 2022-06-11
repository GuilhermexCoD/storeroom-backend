using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IService<TDto> where TDto : EntityBase
    {
        Task<TDto> Add(TDto model);
        Task<TDto> Update(Guid id,TDto model);
        Task<bool> Delete(Guid id);
        void DeleteRange(TDto[] models);

        Task<TDto> GetById(Guid id);

        Task<IEnumerable<TDto>> GetAll();
    }
}