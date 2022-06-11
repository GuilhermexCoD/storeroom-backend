using System;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class ProductPropService : Service<ProductProp,ProductPropDto>, IProductPropService
    {

        public ProductPropService(IProductPropRepository repository,
                                    IMapper mapper) : base(repository,mapper)
        {

        }

        public async Task<ProductPropDto[]> GetAllProductPropsByNameAsync(string name)
        {
            try
            {
                var productPropsModel = await (_repository as IProductPropRepository).GetAllProductPropsByNameAsync(name);

                if(productPropsModel == null)
                    throw new Exception($"Error getting all productProps by name {name} not found.");

                var productPropsDto = _mapper.Map<ProductPropDto[]>(productPropsModel);
                return productPropsDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all productProps by name {name}.",ex);
            }
        }

        public async Task<ProductPropDto[]> GetProductPropsByBarcodeAsync(string barcode)
        {
            try
            {
                var productPropsModel = await (_repository as IProductPropRepository).GetProductPropsByBarcodeAsync(barcode);

                if(productPropsModel == null)
                    throw new Exception($"Error getting all productProps by barcode {barcode} not found.");

                var productPropsDto = _mapper.Map<ProductPropDto[]>(productPropsModel);
                return productPropsDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all productProps by barcode {barcode}.",ex);
            }
        }
    }
}