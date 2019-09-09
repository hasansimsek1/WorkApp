using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;
using WorkApp.DataAccess.Entities;
using WorkApp.Respository.Interfaces;

namespace WorkApp.Service.Services
{
    /// <summary>
    /// Service that is consumed by kanban board related UI elements.
    /// <para/>
    /// Implements : <see cref="IKanbanBoardService"/>
    /// </summary>
    public class KanbanBoardService : IKanbanBoardService
    {
        private readonly ICrudRepository<KanbanBoard, KanbanBoardDto> _kanbanCrudRepository;

        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="ICrudService{KanbanBoard}"/>
        /// </summary>
        public KanbanBoardService(ICrudRepository<KanbanBoard, KanbanBoardDto> kanbanCrudRepository)
        {
            _kanbanCrudRepository = kanbanCrudRepository;
        }

        /// <summary>
        /// Adds new kanban board record and retrieves the newly created record.
        /// </summary>
        /// <param name="newKanbanDto">Data transfer object form of the <see cref="KanbanBoard"/> entity.</param>
        public async Task<Result<KanbanBoardDto>> AddAsync(KanbanBoardDto newKanbanDto)
        {
            return await _kanbanCrudRepository.InsertAsync(newKanbanDto);
        }

        /// <summary>
        /// Retrieves all not deleted kanban board records.
        /// </summary>
        public async Task<Result<List<KanbanBoardDto>>> GetAllAsync()
        {
            return await _kanbanCrudRepository.GetAsync();
        }

        /// <summary>
        /// Retrieves kanban board record with the specified Id.
        /// </summary>
        /// <param name="Id">Id of the kanban board.</param>
        public async Task<Result<KanbanBoardDto>> GetByIdAsync(int Id)
        {
            return await _kanbanCrudRepository.GetAsync(Id);
        }

        /// <summary>
        /// Retrieves kanban board records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<KanbanBoardDto>>> GetByUserIdAsync(string userId)
        {
            return await _kanbanCrudRepository.GetAsync(x => x.UserId == userId);
        }

        /// <summary>
        /// Retrieves not deleted total kanban board count.
        /// </summary>
        public async Task<Result<int>> GetTotalKanbanBoardCountAsync()
        {
            var result = await _kanbanCrudRepository.GetAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }

        /// <summary>
        /// Retrieves total kanban board count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<int>> GetTotalKanbanBoardCountOfUserAsync(string userId)
        {
            var result = await _kanbanCrudRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }

        /// <summary>
        /// Retrieves last edited kanban board record of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardOfUserAsync(string userId)
        {
            var result = await _kanbanCrudRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<KanbanBoardDto>() { Data = null, Errors = result.Errors };
            }

            return new Result<KanbanBoardDto>(result.Data.OrderByDescending(x => x.ModifiedDate).FirstOrDefault());
        }

        /// <summary>
        /// Updates the kanban board record.
        /// </summary>
        public async Task<Result<KanbanBoardDto>> UpdateAsync(KanbanBoardDto kanbanBoardDto)
        {
            var result = await _kanbanCrudRepository.UpdateAsync(kanbanBoardDto);

            if(result.HasError)
            {
                return new Result<KanbanBoardDto>() { Data = null, Errors = result.Errors };
            }

            return new Result<KanbanBoardDto>(result.Data);
        }

        /// <summary>
        /// Soft-deletes the kanban board record.
        /// </summary>
        public async Task<Result<KanbanBoardDto>> DeleteAsync(KanbanBoardDto kanbanBoardDto)
        {
            var result = await _kanbanCrudRepository.DeleteAsync(kanbanBoardDto);

            if(result.HasError)
            {
                return new Result<KanbanBoardDto>() { Data = null, Errors = result.Errors };
            }

            return new Result<KanbanBoardDto>(result.Data);
        }
    }
}
