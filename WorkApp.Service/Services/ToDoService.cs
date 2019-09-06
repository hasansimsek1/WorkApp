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

        public async Task<Result<ToDoDto>> AddAsync(ToDoDto newToDoDto)
        {
            ToDo newToDo = new ToDo
            {
                Text = newToDoDto.Text,
                UserId = newToDoDto.UserId
            };

            var result = await _toDoService.InsertAsync(newToDo);

            if(result.HasError)
            {
                return new Result<ToDoDto> { Data = null };
            }

            newToDoDto.Id = result.Data.Id;

            return new Result<ToDoDto> { Data = newToDoDto };
        }

        public async Task<Result<int>> GetCompletedToDoCountAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }
            
            return new Result<int>() { Data = result.Data.Where(x => x.IsCompleted == true && x.IsDeleted == false && x.UserId == userId).ToList().Count };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetCompletedToDoesAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>() { Data = null, Errors = result.Errors };
            }

            if(result.Data != null)
            {
                var toDoDtoList = result.Data.Where(x => x.IsDeleted == false && x.IsCompleted == true && x.UserId == userId).Select(x => new ToDoDto
                {
                    AddedDate = x.AddedDate,
                    IsDeleted = x.IsDeleted,
                    Id = x.Id,
                    IsCompleted = x.IsCompleted,
                    ModifiedDate = x.ModifiedDate,
                    Text = x.Text,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<ToDoDto>> { Data = toDoDtoList };
            }
            else
            {
                return new Result<IEnumerable<ToDoDto>> { Data = null };
            }
        }

        public async Task<Result<int>> GetIncompleteToDoCountAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsCompleted == false && x.IsDeleted == false && x.UserId == userId).ToList().Count };
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetIncompleteToDoesAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>() { Data = null, Errors = result.Errors };
            }

            if(result.Data != null)
            {
                var toDoDtoList = result.Data.Where(x => x.IsDeleted == false && x.IsCompleted == false && x.UserId == userId).Select(x => new ToDoDto
                {
                    AddedDate = x.AddedDate,
                    IsCompleted = x.IsCompleted,
                    IsDeleted = x.IsDeleted,
                    Id = x.Id,
                    ModifiedDate = x.ModifiedDate,
                    Text = x.Text,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<ToDoDto>> { Data = toDoDtoList };
            }
            else
            {
                return new Result<IEnumerable<ToDoDto>> { Data = null };
            }
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>() { Data = null, Errors = result.Errors };
            }

            if (result.Data != null)
            {
                var toDoDtoList = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).Select(x => new ToDoDto
                {
                    AddedDate = x.AddedDate,
                    IsCompleted = x.IsCompleted,
                    IsDeleted = x.IsDeleted,
                    Id = x.Id,
                    ModifiedDate = x.ModifiedDate,
                    Text = x.Text,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<ToDoDto>> { Data = toDoDtoList };
            }
            else
            {
                return new Result<IEnumerable<ToDoDto>> { Data = null };
            }
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesBetweenDatesAsync(DateTime beingDate, DateTime endDate, string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if(result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>() { Data = null, Errors = result.Errors };
            }

            if (result.Data != null)
            {
                var toDoDtoList = result.Data.Where(x => x.AddedDate < endDate && x.AddedDate > beingDate && x.IsDeleted == false && x.UserId == userId).Select(x => new ToDoDto
                {
                    AddedDate = x.AddedDate,
                    IsCompleted = x.IsCompleted,
                    IsDeleted = x.IsDeleted,
                    Id = x.Id,
                    ModifiedDate = x.ModifiedDate,
                    Text = x.Text,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<ToDoDto>> { Data = toDoDtoList };
            }
            else
            {
                return new Result<IEnumerable<ToDoDto>> { Data = null };
            }
        }

        public async Task<Result<IEnumerable<ToDoDto>>> GetToDoesOfTodayAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<ToDoDto>>() { Data = null, Errors = result.Errors };
            }

            if (result.Data != null)
            {
                var toDoDtoList = result.Data.Where(x => x.AddedDate.Date == DateTime.Now.Date && x.IsDeleted == false && x.UserId == userId).Select(x => new ToDoDto
                {
                    AddedDate = x.AddedDate,
                    IsCompleted = x.IsCompleted,
                    IsDeleted = x.IsDeleted,
                    Id = x.Id,
                    ModifiedDate = x.ModifiedDate,
                    Text = x.Text,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<ToDoDto>> { Data = toDoDtoList };
            }
            else
            {
                return new Result<IEnumerable<ToDoDto>> { Data = null };
            }
        }

        public async Task<Result<int>> GetTotalToDoCountAsync(string userId)
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).ToList().Count };
        }
    }
}
