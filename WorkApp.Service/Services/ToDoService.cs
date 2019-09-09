using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Respository.Interfaces;
using WorkApp.DataAccess.Entities;
using WorkApp.Service.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace WorkApp.Service.Services
{
    /// <summary>
    /// Service that is consumed by todo related UI elements.
    /// <para/>
    /// Implements : <see cref="IToDoService"/>
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly ICrudRepository<ToDo, ToDoDto> _toDoRepository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="ICrudService{ToDo}"/>
        /// </summary>
        public ToDoService(ICrudRepository<ToDo, ToDoDto> toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all todo records.
        /// </summary>
        public async Task<Result<List<ToDoDto>>> GetAllAsync()
        {
            return await _toDoRepository.GetAsync();
        }

        /// <summary>
        /// Retrieves the todo record with given Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Result<ToDoDto>> GetByIdAsync(int Id)
        {
            return await _toDoRepository.GetAsync(Id);
        }

        /// <summary>
        /// Retrieves all todo records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<ToDoDto>>> GetToDoesOfUserAsync(string userId)
        {
            return await _toDoRepository.GetAsync(x => x.UserId == userId);
        }
        
        /// <summary>
        /// Retrieves completed todoes of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<ToDoDto>>> GetCompletedToDoesOfUserAsync(string userId)
        {
            return await _toDoRepository.GetAsync(x => x.UserId == userId && x.IsCompleted == true);
        }
        
        /// <summary>
        /// Retrieves incomplete todoes of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<ToDoDto>>> GetIncompleteToDoesOfUserAsync(string userId)
        {
            return await _toDoRepository.GetAsync(x => x.UserId == userId && x.IsCompleted == false);
        }
        
        /// <summary>
        /// Retrieves total todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<int>> GetTotalToDoCountOfUserAsync(string userId)
        {
            var result = await _toDoRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }
        
        /// <summary>
        /// Retrieves total completed todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<int>> GetCompletedToDoCountOfUserAsync(string userId)
        {
            var result = await _toDoRepository.GetAsync(x => x.UserId == userId && x.IsCompleted == true);

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }
        
        /// <summary>
        /// Retrieves total incomplete todo count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<int>> GetIncompleteToDoCountOfUserAsync(string userId)
        {
            var result = await _toDoRepository.GetAsync(x => x.UserId == userId && x.IsCompleted == false);

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }
        
        /// <summary>
        /// Retrieves todoes of user that added for today.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<ToDoDto>>> GetToDoesOfUserOfTodayAsync(string userId)
        {
            return await _toDoRepository.GetAsync(x => x.AddedDate.Date == DateTime.Now.Date || x.ModifiedDate.Date == DateTime.Now.Date);
        }


        /// <summary>
        /// Retrieves todoes of the user between two dates.
        /// </summary>
        /// <param name="beginDate">Beginning date of the search.</param>
        /// <param name="endDate">End date of the search.</param>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<ToDoDto>>> GetToDoesOfUserBetweenDatesAsync(DateTime beginDate, DateTime endDate, string userId)
        {
            // SIMPLE CODE KATA FOR FUN.. DON'T TAKE IT SERIOUSLY..

            //Expression<Func<ToDo, bool>> TodoesOfUserBetweenDatesExpression = x =>                     
            Func<ToDo, bool> func = x =>
                    (x.AddedDate > beginDate || x.ModifiedDate > beginDate)     // 
                    &&
                    (x.AddedDate < endDate || x.ModifiedDate < endDate)
                    &&
                    x.UserId == userId;

            Expression<Func<ToDo, bool>> expression = exp => func(exp);
            
            return await _toDoRepository.GetAsync(expression);
        }
        

        /// <summary>
        /// Adds new todo record and returns back <see cref="ToDoDto"/> with created entity Id.
        /// </summary>
        public async Task<Result<ToDoDto>> AddAsync(ToDoDto newToDoDto)
        {
            return await _toDoRepository.InsertAsync(newToDoDto);
        }

        /// <summary>
        /// Updates the todo record.
        /// </summary>
        public async Task<Result<ToDoDto>> UpdateAsync(ToDoDto toDoDto)
        {
            return await _toDoRepository.UpdateAsync(toDoDto);
        }
    }
}
