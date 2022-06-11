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
    public class ProductStatusController : ControllerBase
    {
        private readonly IProductStatusService _service;

        public ProductStatusController(IProductStatusService service)
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
                    $"Error while trying to get productStatus | Erro: {ex.Message}");
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
                    $"Error while trying to get ProductStatus {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetAllProductStatusByTypeAsync(string type)
        {
            try
            {
                var product = await _service.GetAllProductStatusByTypeAsync(type);
                
                if(product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get ProductStatus with type: {type} | Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ProductStatusDto model)
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
                    $"Error while trying to add ProductStatus : {model} | Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ProductStatusDto model){

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
                    $"Error while trying to update ProductStatus : {model} | Erro: {ex.Message}");
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
                    $"Error while trying to delete a ProductStatus : {id} | Erro: {ex.Message}");
            }
        }

    }
}
