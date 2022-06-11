using System;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class UserService : Service<User,UserDto>, IUserService
    {

        public UserService(IUserRepository repository,
                            IMapper mapper) : base(repository,mapper)
        {

        }

        public async Task<UserDto[]> GetAllUsersByFamilyIdAsync(Guid id)
        {
            try
            {
                var usersModel = await (_repository as IUserRepository)
                                    .GetAllUsersByFamilyIdAsync(id);

                if(usersModel == null)
                    throw new Exception($"Error getting all Users by id {id} not found.");

                var usersDto = _mapper.Map<UserDto[]>(usersModel);

                return usersDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all Users by id {id}.",ex);
            }
        }

        public async Task<UserDto[]> GetAllUsersByFamilyNameAsync(string name)
        {
            try
            {
                var usersModel = await (_repository as IUserRepository)
                                    .GetAllUsersByFamilyNameAsync(name);

                if(usersModel == null)
                    throw new Exception($"Error getting all Users by Family name {name} not found.");

                var usersDto = _mapper.Map<UserDto[]>(usersModel);

                return usersDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all Users by Family name {name}.",ex);
            }
        }

        public async Task<UserDto[]> GetAllUsersByNameAsync(string name)
        {
            try
            {
                var usersModel = await (_repository as IUserRepository)
                                    .GetAllUsersByNameAsync(name);

                if(usersModel == null)
                    throw new Exception($"Error getting all Users by name {name} not found.");

                var usersDto = _mapper.Map<UserDto[]>(usersModel);

                return usersDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all Users by name {name}.",ex);
            }
        }
    }
}