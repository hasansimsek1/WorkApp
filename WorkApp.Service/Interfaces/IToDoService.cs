using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;

namespace WorkApp.Service.Interfaces
{
    public interface IToDoService : IService
    {
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesAsync();
        Task<Result<IEnumerable<ToDoDto>>> GetCompletedToDoesAsync();
        Task<Result<IEnumerable<ToDoDto>>> GetIncompleteToDoesAsync();
        Task<Result<int>> GetTotalToDoCountAsync();
        Task<Result<int>> GetCompletedToDoCountAsync();
        Task<Result<int>> GetIncompleteToDoCountAsync();
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesOfToday();
        Task<Result<IEnumerable<ToDoDto>>> GetToDoesBetweenDates(DateTime beingDate, DateTime endDate);
    }
}
