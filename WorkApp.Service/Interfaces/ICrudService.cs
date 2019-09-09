using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Interfaces;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Base service definitions that interracts with repositories.
    /// Only responsible for CRUD operations.
    /// Individual services depend on this definitions and interract repositories through implementation of this interface.
    /// </summary>
    /// <typeparam name="T">Individual service class that communicates with UI.</typeparam>
    public interface ICrudService<TEntity, TDto> : IService
        where TEntity : class, IEntityWithCommonProperties
    {
        /// <summary>
        /// Retrieves all records of the entity from repository.
        /// </summary>
        Task<Result<List<T>>> GetAllAsync();

        /// <summary>
        /// Retrieves one entity record with the specified Id.
        /// </summary>
        /// <param name="Id">Id of the entity.</param>
        Task<Result<T>> GetByIdAsync(int Id);

        /// <summary>
        /// Retrieves the entity records with the specified filters
        /// </summary>
        Task<Result<List<T>>> GetByFilterAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Adds new entity to the persistance mechanism.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        Task<Result<T>> InsertAsync(T entity);

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        Task<Result<T>> UpdateAsync(T entity);

        /// <summary>
        /// Performs soft-delete operation the the specified entity record.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        Task<Result<T>> DeleteAsync(T entity);
    }
}
