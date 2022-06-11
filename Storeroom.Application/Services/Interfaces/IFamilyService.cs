using System.Threading.Tasks;
using Storeroom.Application.Dtos;

namespace Storeroom.Application.Services.Interfaces
{
    public interface IFamilyService : IService<FamilyDto>
    {
        Task<FamilyDto[]> GetAllFamilyByNameAsync(string name);
    }
}