using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storeroom.Application.Dtos;
using Storeroom.Application.Services.Interfaces;

namespace StoreroomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var products = await _service.GetAll();
                
                if(products == null)
                    return NoContent();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get product | Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var product = await _service.GetById(id);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get product {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetAllProductsByName(string name)
        {
            try
            {
                var product = await _service.GetAllProductsByNameAsync(name);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get product with name: {name} | Erro: {ex.Message}");
            }
        }

        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetProductsByBarcodeAsync(string barcode)
        {
            try
            {
                var product = await _service.GetProductsByBarcodeAsync(barcode);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get product with barcode: {barcode} | Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ProductDto model)
        {
            try
            {
                var product = await _service.Add(model);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to add product : {model} | Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ProductDto model){

            try
            {
                var product = await _service.Update(id, model);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to update product : {model} | Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){

            try
            {
                var result = await _service.Delete(id);
                
                if(!result)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to delete a product : {id} | Erro: {ex.Message}");
            }
        }

    }
}
