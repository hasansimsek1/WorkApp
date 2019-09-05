using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ICrudService<ToDo> _toDoService;

        public ToDoService(ICrudService<ToDo> toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<Result<int>> GetCompletedToDoCountAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }
            
            return new Result<int>() { Data = result.Data.Where(x => x.IsCompleted == true && x.IsDeleted == false).ToList().Count };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetCompletedToDoesAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            return new Result<IEnumerable<ToDoDto>>() { Data = result.Data.Where(x => x.IsCompleted == true && x.IsDeleted == false).ToList().Cast<ToDoDto>()};
        }

        public async Task<Result<int>> GetIncompleteToDoCountAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>()
                {
                    Data = 0,
                    Errors = result.Errors
                };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsCompleted == false && x.IsDeleted == false).ToList().Count };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetIncompleteToDoesAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            return new Result<IEnumerable<ToDoDto>>() { Data = result.Data.Where(x => x.IsCompleted == false && x.IsDeleted == false).ToList().Cast<ToDoDto>() };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            return new Result<IEnumerable<ToDoDto>>() { Data = result.Data.Where(x => x.IsDeleted == false).ToList().Cast<ToDoDto>() };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesBetweenDatesAsync(DateTime beingDate, DateTime endDate)
        {
            var result = await _toDoService.GetAllAsync();

            if(result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            return new Result<IEnumerable<ToDoDto>>() { Data = result.Data.Where(x => x.AddedDate < endDate && x.AddedDate > beingDate && x.IsDeleted == false).ToList().Cast<ToDoDto>() };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesOfTodayAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            return new Result<IEnumerable<ToDoDto>>() { Data = result.Data.Where(x => x.AddedDate.Date == DateTime.Now.Date && x.IsDeleted == false).ToList().Cast<ToDoDto>() };
        }

        public async Task<Result<int>> GetTotalToDoCountAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>()
                {
                    Data = 0,
                    Errors = result.Errors
                };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsDeleted == false).ToList().Count };
        }
    }
}
