using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Interfaces;

namespace Storeroom.Application.Services
{
    public class Service<TModel,TDto> : IService<TDto> where TModel : EntityBase where TDto : EntityBase
    {
        protected readonly IRepository<TModel> _repository;
        protected IMapper _mapper;

        public Service(IRepository<TModel> repository,
                        IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> Add(TDto modelDto)
        {
            try
            {
                var model = _mapper.Map<TModel>(modelDto);
                
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    var resultGet = await _repository.GetByIdAsync(model.Id);
                    return _mapper.Map<TDto>(resultGet);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding {modelDto}.",ex);
            }
        }

        public async Task<TDto> Update(Guid id,TDto modelDto)
        {
            try
            {
                var resultModel = await _repository.GetByIdAsync(id);

                if(resultModel == null)
                    return null;

                modelDto.Id = resultModel.Id;

                _mapper.Map(modelDto, resultModel);

                _repository.Update(resultModel);

                if (await _repository.SaveChangesAsync())
                {
                    var result = await _repository.GetByIdAsync(resultModel.Id);
                    return _mapper.Map<TDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating {modelDto}. | {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);

                if(result == null)
                    throw new Exception($"Error {id} not found.");

                _repository.Delete(result);

                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting {id}.",ex);
            }
        }

        public void DeleteRange(TDto[] modelsDto)
        {
            try
            {
                var models = _mapper.Map<TModel[]>(modelsDto);
                _repository.DeleteRange(models);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting range.",ex);
            }
        }

        public async Task<TDto> GetById(Guid id)
        {
            try
            {
                var resultModel = await _repository.GetByIdAsync(id);

                if(resultModel == null)
                    throw new Exception($"Error {id} not found.");

                var result = _mapper.Map<TDto>(resultModel);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting {id}.",ex);
            }
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            try
            {
                var resultModels = await _repository.GetAll();

                if(resultModels == null)
                    throw new Exception($"Error getting all result null.");

                var results = _mapper.Map<TDto[]>(resultModels);

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all",ex);
            }
        }
    }
}