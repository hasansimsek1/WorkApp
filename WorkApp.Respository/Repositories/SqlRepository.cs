using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Enums;
using WorkApp.Common.Interfaces;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;

namespace WorkApp.Respository.Repositories
{
    public class SqlRespository<T> : ICrudRepository<T> where T : class, IEntity
    {
        private DbContext _dbContext;
        private DbSet<T> _entity;

        

        public SqlRespository(DbContextOptions<AppDbContext> options)
        {
            _dbContext = new AppDbContext(options);
            _entity = _dbContext.Set<T>();
        }



        public async Task<Result<IEnumerable<T>>> GetAsync()
        {
            try
            {
                return new Result<IEnumerable<T>>()
                {
                    Data = await _entity.ToListAsync(),
                };
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<T>>(ex, ExceptionLocations.SqlRepositoryGet);
            }
        }

        public async Task<Result<T>> GetAsync(int Id)
        {
            try
            {
                return new Result<T>()
                {
                    Data = await _entity.FindAsync(Id)
                };
            }
            catch (Exception ex)
            {
                return new Result<T>(ex, ExceptionLocations.SqlRepositoryGetById);
            }
        }

        public async Task<Result<IEnumerable<T>>> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                return new Result<IEnumerable<T>>()
                {
                    Data = await _entity.Where(filter).ToListAsync()
                };
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<T>>(ex, ExceptionLocations.SqlRepositoryGetByFilter);
            }
        }



        public async Task<Result<T>> InsertAsync(T entity)
        {
            try
            {
                entity.IsDeleted = false;
                entity.AddedDate = DateTime.Now;
                _entity.Add(entity);
                await Save();
                return new Result<T>(entity);
            }
            catch (Exception ex)
            {
                return new Result<T>(ex, ExceptionLocations.SqlRepositoryInsert, entity);
            }

        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
            try
            {
                entity.ModifiedDate = DateTime.Now;
                _dbContext.Entry(entity).State = EntityState.Modified;
                await Save();
                return new Result<T>(entity);
            }
            catch (Exception ex)
            {
                return new Result<T>(ex, ExceptionLocations.SqlRepositoryUpdate, entity);
            }
        }

        public async Task<Result<T>> DeleteAsync(T entity)
        {
            try
            {
                entity.IsDeleted = true;
                entity.ModifiedDate = DateTime.Now;
                _dbContext.Entry(entity).State = EntityState.Modified;
                await Save();
                return new Result<T>(entity);
            }
            catch (Exception ex)
            {
                return new Result<T>(ex, ExceptionLocations.SqlRepositoryDelete, entity);
            }
        }



        /// <summary>
        /// Async wrapper for DbContex.SaveCahnges() method.
        /// </summary>
        private async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }



        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }
                disposed = true;
            }
        }
    }
}
