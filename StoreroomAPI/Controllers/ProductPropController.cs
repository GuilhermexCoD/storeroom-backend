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
    public class ProductPropController : ControllerBase
    {
        private readonly IProductPropService _service;

        public ProductPropController(IProductPropService service)
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
                    $"Error while trying to get productProps | Erro: {ex.Message}");
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
                    $"Error while trying to get ProductProp {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetAllProductsByName(string name)
        {
            try
            {
                var product = await _service.GetAllProductPropsByNameAsync(name);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get ProductProp with name: {name} | Erro: {ex.Message}");
            }
        }

        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetProductsByBarcodeAsync(string barcode)
        {
            try
            {
                var product = await _service.GetProductPropsByBarcodeAsync(barcode);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get ProductProp with barcode: {barcode} | Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ProductPropDto model)
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
                    $"Error while trying to add ProductProp : {model} | Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ProductPropDto model){

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
                    $"Error while trying to update ProductProp : {model} | Erro: {ex.Message}");
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
                    $"Error while trying to delete a ProductProp : {id} | Erro: {ex.Message}");
            }
        }

    }
}
