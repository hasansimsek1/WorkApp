using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Interfaces;
using WorkApp.Repository.Interfaces;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, IEntity
    {
        private readonly ICrudRepository<T> _repository;



        public CrudService(ICrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Result<T>> GetByIdAsync(int Id)
        {
            return await _repository.GetAsync(Id);
        }



        public async Task<Result<T>> InsertAsync(T entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<Result<T>> DeleteAsync(T entity)
        {
            return await _repository.DeleteAsync(entity);
        }
    }
}
