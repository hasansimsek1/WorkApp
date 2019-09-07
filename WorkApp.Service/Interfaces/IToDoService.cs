using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    public interface IToDoService : IService
    {
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesAsync(string userId);
        Task<Result<IEnumerable<ToDoDto>>> GetCompletedToDoesAsync(string userId);
        Task<Result<IEnumerable<ToDoDto>>> GetIncompleteToDoesAsync(string userId);
        Task<Result<int>> GetTotalToDoCountAsync(string userId);
        Task<Result<int>> GetCompletedToDoCountAsync(string userId);
        Task<Result<int>> GetIncompleteToDoCountAsync(string userId);
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesOfTodayAsync(string userId);
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesBetweenDatesAsync(DateTime beingDate, DateTime endDate, string userId);
        Task<Result<ToDoDto>> AddAsync(ToDoDto newToDoDto);
    }
}
