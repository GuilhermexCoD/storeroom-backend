using System;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class ProductStatusService : Service<ProductStatus,ProductStatusDto>, IProductStatusService
    {

        public ProductStatusService(IProductStatusRepository repository,
                                        IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<ProductStatusDto[]> GetAllProductStatusByTypeAsync(string type)
        {
            try
            {
                var productStatusesModel = await (_repository as IProductStatusRepository).
                                            GetAllProductStatusByTypeAsync(type);

                if(productStatusesModel == null)
                    throw new Exception($"Error getting all ProductStatus by type {type} not found.");

                var productStatusesDto = _mapper.Map<ProductStatusDto[]>(productStatusesModel);
                return productStatusesDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all ProductStatus by type {type}.",ex);
            }
        }
    }
}