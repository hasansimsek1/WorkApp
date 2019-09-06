using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class KanbanBoardService : IKanbanBoardService
    {
        private readonly ICrudService<KanbanBoard> _kanbanCrudService;

        public KanbanBoardService(ICrudService<KanbanBoard> kanbanCrudService)
        {
            _kanbanCrudService = kanbanCrudService;
        }

        public async Task<Result<KanbanBoardDto>> AddAsync(KanbanBoardDto newKanbanDto)
        {
            KanbanBoard newKanbanBoardEntity = new KanbanBoard
            {
                Name = newKanbanDto.Name,
                AddedDate = DateTime.Now,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                UserId = newKanbanDto.UserId
                
            };

            var result = await _kanbanCrudService.InsertAsync(newKanbanBoardEntity);

            if (result.HasError)
            {
                return new Result<KanbanBoardDto> { Data = null, Errors = result.Errors };
            }

            newKanbanDto.Id = result.Data.Id;

            return new Result<KanbanBoardDto> { Data = newKanbanDto };
        }

        public async Task<Result<IEnumerable<KanbanBoardDto>>> GetAllAsync(string userId)
        {
            var result = await _kanbanCrudService.GetAllAsync();

            if(result.HasError)
            {
                return new Result<IEnumerable<KanbanBoardDto>> { Data = null, Errors = result.Errors };
            }

            if (result.Data != null)
            {
                var kanbanDtoList = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).Select(x => new KanbanBoardDto
                {
                    AddedDate = x.AddedDate,
                    Columns = x.Columns,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    ModifiedDate = x.ModifiedDate,
                    Name = x.Name,
                    User = x.User,
                    UserId = userId
                });

                return new Result<IEnumerable<KanbanBoardDto>> { Data = kanbanDtoList };
            }
            else
            {
                return new Result<IEnumerable<KanbanBoardDto>> { Data = null };
            }
        }

        public async Task<Result<KanbanBoardDto>> GetByIdAsync(int Id)
        {
            var result = await _kanbanCrudService.GetByIdAsync(Id);

            if(result.HasError)
            {
                return new Result<KanbanBoardDto> { Data = null, Errors = result.Errors };
            }

            KanbanBoardDto kanbanBoardDto = new KanbanBoardDto();

            if(result.Data != null)
            {
                kanbanBoardDto = new KanbanBoardDto
                {
                    AddedDate = result.Data.AddedDate,
                    Columns = result.Data.Columns,
                    Id = result.Data.Id,
                    ModifiedDate = result.Data.ModifiedDate,
                    Name = result.Data.Name,
                    UserId = result.Data.UserId
                };
            }
            return new Result<KanbanBoardDto> { Data = kanbanBoardDto };
        }

        public async Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardAsync(string userId)
        {
            var result = await _kanbanCrudService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<KanbanBoardDto>()
                {
                    Data = null,
                    Errors = result.Errors
                };
            }

            var kanbanBoard = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).OrderByDescending(x => x.ModifiedDate).FirstOrDefault();

            KanbanBoardDto kanbanBoardDto = new KanbanBoardDto();
            
            if(kanbanBoard != null)
            {
                kanbanBoardDto = new KanbanBoardDto
                {
                    Id = kanbanBoard.Id,
                    Name = kanbanBoard.Name,
                    AddedDate = kanbanBoard.AddedDate,
                    ModifiedDate = kanbanBoard.ModifiedDate,
                    Columns = kanbanBoard.Columns,
                    IsDeleted = kanbanBoard.IsDeleted,
                    User = kanbanBoard.User,
                    UserId = kanbanBoard.UserId
                };
            }
            

            return new Result<KanbanBoardDto>() { Data = kanbanBoardDto };
        }

        public async Task<Result<int>> GetTotalKanbanBoardCountAsync(string userId)
        {
            var result = await _kanbanCrudService.GetAllAsync();

            if (result.HasError)
            {
                return new Result<int>() { Data = 0, Errors = result.Errors };
            }

            return new Result<int>() { Data = result.Data.Where(x => x.IsDeleted == false && x.UserId == userId).ToList().Count };
        }
    }
}
