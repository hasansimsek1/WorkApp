using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly ICrudService<Note> _noteCrudService;

        public NoteService(ICrudService<Note> noteCrudService)
        {
            _noteCrudService = noteCrudService;
        }

        public async Task<Result<IEnumerable<NoteDto>>> GetAllAsync(string userId)
        {
            var result = await _noteCrudService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<IEnumerable<NoteDto>>() { Data = null, Errors = result.Errors };
            }

            if(result.Data != null)
            {
                var noteDtoList = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).Select(x => new NoteDto
                {
                    AddedDate = x.AddedDate,
                    IsDeleted = x.IsDeleted,
                    Content = x.Content,
                    Id = x.Id,
                    ModifiedDate = x.ModifiedDate,
                    Tags = x.Tags,
                    Title = x.Title,
                    User = x.User,
                    UserId = x.UserId
                });

                return new Result<IEnumerable<NoteDto>> { Data = noteDtoList };
            }
            else
            {
                return new Result<IEnumerable<NoteDto>> { Data = null };
            }
        }

        public async Task<Result<NoteDto>> GetLastEditedNoteAsync(string userId)
        {
            var result = await _noteCrudService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<NoteDto>() { Data = null, Errors = result.Errors };
            }

            var note = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).OrderByDescending(x => x.ModifiedDate).FirstOrDefault();

            NoteDto noteDto = new NoteDto();

            if (note != null)
            {
                noteDto = new NoteDto
                {
                    Id = note.Id,
                    Title = note.Title,
                    Content = note.Content,
                    AddedDate = note.AddedDate,
                    ModifiedDate = note.ModifiedDate,
                    IsDeleted = note.IsDeleted,
                    Tags = note.Tags.ToList(),
                    User = note.User,
                    UserId = note.UserId
                };
            }
            
            return new Result<NoteDto>() { Data = noteDto };
        }

        public async Task<Result<int>> GetTotalNoteCountAsync(string userId)
        {
            var result = await _noteCrudService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).ToList().Count };
        }
    }
}
