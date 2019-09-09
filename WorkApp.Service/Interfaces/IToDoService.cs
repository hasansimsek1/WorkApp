using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Definitions of operations that consumed by the todo feature of the app.
    /// </summary>
    public interface IToDoService : IService
    {
        /// <summary>
        /// Retrieves all todo records.
        /// </summary>
        Task<Result<List<ToDoDto>>> GetAllAsync();

        /// <summary>
        /// Retrieves todo record with given Id
        /// </summary>
        /// <param name="id">Id of the todo item.</param>
        Task<Result<ToDoDto>> GetByIdAsync(int Id);

        /// <summary>
        /// Retrieves all todo records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<ToDoDto>>> GetToDoesOfUserAsync(string userId);

        /// <summary>
        /// Retrieves completed todoes of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<ToDoDto>>> GetCompletedToDoesOfUserAsync(string userId);

        /// <summary>
        /// Retrieves incomplete todoes of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<ToDoDto>>> GetIncompleteToDoesOfUserAsync(string userId);

        /// <summary>
        /// Retrieves total todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<int>> GetTotalToDoCountOfUserAsync(string userId);

        /// <summary>
        /// Retrieves total completed todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<int>> GetCompletedToDoCountOfUserAsync(string userId);

        /// <summary>
        /// Retrieves total incomplete todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<int>> GetIncompleteToDoCountOfUserAsync(string userId);

        /// <summary>
        /// Retrieves todoes of user that added for today.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<ToDoDto>>> GetToDoesOfUserOfTodayAsync(string userId);
        
        /// <summary>
        /// Retrieves todoes of the user between two dates.
        /// </summary>
        /// <param name="beginDate">Beginning date of the search.</param>
        /// <param name="endDate">End date of the search.</param>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<ToDoDto>>> GetToDoesOfUserBetweenDatesAsync(DateTime beginDate, DateTime endDate, string userId);

        /// <summary>
        /// Adds new todo.
        /// </summary>
        /// <param name="newToDoDto">New todo entity to be added.</param>
        Task<Result<ToDoDto>> AddAsync(ToDoDto newToDoDto);

        /// <summary>
        /// Upte the todo.
        /// </summary>
        Task<Result<ToDoDto>> UpdateAsync(ToDoDto toDoDto);
    }
}
