using System;
using System.Threading.Tasks;
using Storeroom.Application.Dtos;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        Task<UserDto[]> GetAllUsersByNameAsync(string name);
        Task<UserDto[]> GetAllUsersByFamilyIdAsync(Guid id);
        Task<UserDto[]> GetAllUsersByFamilyNameAsync(string name);
    }
}