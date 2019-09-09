using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Entities;
using WorkApp.Common.Extensions;
using WorkApp.Service.Interfaces;
using WorkApp.Respository.Interfaces;

namespace WorkApp.Service.Services
{
    /// <summary>
    /// Service that is consumed by note taking related UI elements.
    /// <para/>
    /// Implements : <see cref="INoteService"/>
    /// </summary>
    public class NoteService : INoteService
    {
        private readonly ICrudRepository<Note, NoteDto> _noteCrudRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for getting dependency injection. Dependencies : <see cref="ICrudService{T}"/>
        /// </summary>
        public NoteService(ICrudRepository<Note, NoteDto> noteCrudRepository, IMapper mapper)
        {
            _noteCrudRepository = noteCrudRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves note records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<List<NoteDto>>> GetByUserId(string userId)
        {
            var result = await _noteCrudRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<List<NoteDto>>() { Data = null, Errors = result.Errors };
            }

            return new Result<List<NoteDto>>(result.Data);
        }

        /// <summary>
        /// Retrieves last edited note record by the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<NoteDto>> GetLastEditedNoteOfUserAsync(string userId)
        {
            var result = await _noteCrudRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<NoteDto>() { Data = null, Errors = result.Errors };
            }

            return new Result<NoteDto>(result.Data.OrderByDescending(x => x.Id).FirstOrDefault());
        }

        /// <summary>
        /// Retrieves total note records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        public async Task<Result<int>> GetTotalNoteCountOfUserAsync(string userId)
        {
            var result = await _noteCrudRepository.GetAsync(x => x.UserId == userId);

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>(result.Data.Count);
        }
    }
}
