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
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _service;

        public FamilyController(IFamilyService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var families = await _service.GetAll();
                
                if(families == null)
                    return NoContent();

                return Ok(families);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get families | Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var family = await _service.GetById(id);
                
                if(family == null)
                    return NoContent();

                return Ok(family);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get Family {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetAllFamilyByNameAsync(string name)
        {
            try
            {
                var families = await _service.GetAllFamilyByNameAsync(name);
                
                if(families == null)
                    return NoContent();

                return Ok(families);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get Families with name: {name} | Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(FamilyDto model)
        {
            try
            {
                var family = await _service.Add(model);
                
                if(family == null)
                    return NoContent();

                return Ok(family);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to add family : {model} | Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FamilyDto model){

            try
            {
                var family = await _service.Update(id, model);
                
                if(family == null)
                    return NoContent();

                return Ok(family);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to update family : {model} | Erro: {ex.Message}");
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
                    $"Error while trying to delete a Family : {id} | Erro: {ex.Message}");
            }
        }

    }
}
