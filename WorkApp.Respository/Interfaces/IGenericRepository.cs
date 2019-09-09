using System;
using WorkApp.Common.Interfaces;
using WorkApp.DataAccess.Interfaces;

namespace WorkApp.Respository.Interfaces
{
    /// <summary>
    /// Base criterias of the generic repositories.
    /// </summary>
    public interface IGenericRepository<TEntity, TDto> : IRepository
        where TDto : class, IDto 
        where TEntity : class, IEntity
    {
    }
}
