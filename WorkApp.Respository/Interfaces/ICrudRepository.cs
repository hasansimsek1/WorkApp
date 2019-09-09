using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Interfaces;
using WorkApp.DataAccess.Interfaces;

namespace WorkApp.Respository.Interfaces
{
    /// <summary>
    /// Generic repository pattern definition with CRUD operations to be implemented by the app repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudRepository<TEntity, TDto> : IGenericRepository<TEntity, TDto> 
        where TDto : class, IDtoWithCommonProperties
        where TEntity : class, IEntityWithCommonProperties
    {
        /// <summary>
        /// Retrieve all the entity records.
        /// </summary>
        Task<Result<List<TDto>>> GetAsync();

        /// <summary>
        /// Retrieve the entity with the specified Id.
        /// </summary>
        /// <param name="Id">Id of the entiry to be retrieved.</param>
        Task<Result<TDto>> GetAsync(int Id);

        /// <summary>
        /// Retrieve entities with specified filters.
        /// </summary>
        Task<Result<List<TDto>>> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Insert operation of new entity.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        Task<Result<TDto>> InsertAsync(TDto entityDto);

        /// <summary>
        /// Update operation of existing entity.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        Task<Result<TDto>> UpdateAsync(TDto entityDto);

        /// <summary>
        /// Soft-delete operation of the entity.
        /// </summary>
        /// <param name="entity">Entity to be soft-deleted.</param>
        /// <returns></returns>
        Task<Result<TDto>> DeleteAsync(TDto entityDto);


    }
}
