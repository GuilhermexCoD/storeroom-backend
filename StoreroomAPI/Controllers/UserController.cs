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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var users = await _service.GetAll();
                
                if(users == null)
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get users | Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var user = await _service.GetById(id);
                
                if(user == null)
                    return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get User {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("family/name/{name}")]
        public async Task<IActionResult> GetAllUsersByFamilyNameAsync(string name)
        {
            try
            {
                var users = await _service.GetAllUsersByFamilyNameAsync(name);
                
                if(users == null)
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get Users with Family name: {name} | Erro: {ex.Message}");
            }
        }

        [HttpGet("family/id/{id}")]
        public async Task<IActionResult> GetAllUsersByFamilyIdAsync(Guid id)
        {
            try
            {
                var users = await _service.GetAllUsersByFamilyIdAsync(id);
                
                if(users == null)
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get Users with Family id: {id} | Erro: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetAllUsersByNameAsync(string name)
        {
            try
            {
                var users = await _service.GetAllUsersByNameAsync(name);
                
                if(users == null)
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to get Users with name: {name} | Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(UserDto model)
        {
            try
            {
                var user = await _service.Add(model);
                
                if(user == null)
                    return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to add user : {model} | Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UserDto model){

            try
            {
                var user = await _service.Update(id, model);
                
                if(user == null)
                    return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to update user : {model} | Erro: {ex.Message}");
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
                    $"Error while trying to delete a User : {id} | Erro: {ex.Message}");
            }
        }

    }
}
