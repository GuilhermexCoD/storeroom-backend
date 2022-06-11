using System;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class FamilyService : Service<Family,FamilyDto>, IFamilyService
    {

        public FamilyService(IFamilyRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<FamilyDto[]> GetAllFamilyByNameAsync(string name)
        {
            try
            {
                var familiesModel = await (_repository as IFamilyRepository)
                                    .GetAllFamiliesByNameAsync(name);

                if(familiesModel == null)
                    throw new Exception($"Error getting all Families by name {name} not found.");

                var familiesDto = _mapper.Map<FamilyDto[]>(familiesModel);
                return familiesDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all Families by name {name}.",ex);
            }
        }
    }
}