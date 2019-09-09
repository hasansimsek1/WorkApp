using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Interfaces;
using WorkApp.Respository.Interfaces;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    /// <summary>
    /// Implementation of <see cref="ICrudService{T}"/>. 
    /// Responsible for interracting with repositories.
    /// </summary>
    /// <typeparam name="T">An entity class that implements IEntity interface.</typeparam>
    public class CrudService<T> : ICrudService<T> where T : class, IEntityWithCommonProperties
    {
        private readonly ICrudRepository<T> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="ICrudRepository{T}"/>
        /// </summary>
        public CrudService(ICrudRepository<TEntity, TDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all records of the entity from repository.
        /// </summary>
        public async Task<Result<List<T>>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        /// <summary>
        /// Retrieves one entity record with the specified Id.
        /// </summary>
        /// <param name="Id">Id of the entity.</param>
        public async Task<Result<T>> GetByIdAsync(int Id)
        {
            return await _repository.GetAsync(Id);
        }

        /// <summary>
        /// Retrieves the entity records with the specified filters
        /// </summary>
        public async Task<Result<List<T>>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _repository.GetAsync(filter);
        }

        /// <summary>
        /// Adds new entity to the persistance mechanism.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        public async Task<Result<T>> InsertAsync(T entity)
        {
            return await _repository.InsertAsync(entity);
        }

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        public async Task<Result<T>> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// Performs soft-delete operation the the specified entity record.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        public async Task<Result<T>> DeleteAsync(T entity)
        {
            return await _repository.DeleteAsync(entity);
        }


    }
}
