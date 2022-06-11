using System;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class ProductService : Service<Product,ProductDto>, IProductService
    {

        public ProductService(IProductRepository repository,
                                IMapper mapper) : base(repository, mapper)
        {
            
        }

        public async Task<ProductDto[]> GetAllProductsByNameAsync(string name)
        {
            try
            {
                var resultModel = await (_repository as IProductRepository).GetAllProductsByNameAsync(name);

                if(resultModel == null)
                    throw new Exception($"Error getting all products by name {name} not found.");

                var result = _mapper.Map<ProductDto[]>(resultModel);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all products by name {name}.",ex);
            }
        }

        public async Task<ProductDto[]> GetProductsByBarcodeAsync(string barcode)
        {
            try
            {
                var resultModel = await (_repository as IProductRepository).GetProductsByBarcodeAsync(barcode);

                if(resultModel == null)
                    throw new Exception($"Error getting all products by barcode {barcode} not found.");

                var result = _mapper.Map<ProductDto[]>(resultModel);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all products by barcode {barcode}.",ex);
            }
        }
    }
}