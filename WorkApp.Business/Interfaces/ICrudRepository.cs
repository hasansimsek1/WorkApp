using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Business.Interfaces
{
    public interface ICrudRepository<T> : IRepository<T> where T : class
    {
        Task<Result<T>> InsertAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(T entity);

        Task<Result<IEnumerable<T>>> GetAsync();
        Task<Result<T>> GetAsync(int Id);
        Task<Result<IEnumerable<T>>> GetAsync(Expression<Func<T, bool>> filter);
    }
}
