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

        public async Task<Result<IEnumerable<KanbanBoardDto>>> GetAllAsync()
        {
            var result = await _kanbanCrudService.GetAllAsync();

            if(result.HasError)
            {
                return new Result<IEnumerable<KanbanBoardDto>> { Data = null, Errors = result.Errors };
            }

            return new Result<IEnumerable<KanbanBoardDto>> { Data = result.Data.Where(x => x.IsDeleted == false).Cast<KanbanBoardDto>() };
        }

        public async Task<Result<KanbanBoardDto>> GetByIdAsync(int Id)
        {
            var result = await _kanbanCrudService.GetByIdAsync(Id);

            if(result.HasError)
            {
                return new Result<KanbanBoardDto> { Data = null, Errors = result.Errors };
            }
            
            return new Result<KanbanBoardDto>
            {
                Data = new KanbanBoardDto
                {
                    AddedDate = result.Data.AddedDate,
                    Columns = result.Data.Columns,
                    Id = result.Data.Id,
                    ModifiedDate = result.Data.ModifiedDate,
                    Name = result.Data.Name,
                    UserId = result.Data.UserId
                }
            };
        }

        public async Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardAsync()
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

            var kanbanBoard = result.Data.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ModifiedDate).FirstOrDefault();

            KanbanBoardDto kanbanBoardDto = new KanbanBoardDto();
            
            if(kanbanBoard != null)
            {
                kanbanBoardDto = new KanbanBoardDto
                {
                    Id = kanbanBoard.Id,
                    Name = kanbanBoard.Name,
                    AddedDate = kanbanBoard.AddedDate,
                    ModifiedDate = kanbanBoard.ModifiedDate
                };
            }
            

            return new Result<KanbanBoardDto>() { Data = kanbanBoardDto };
        }

        public async Task<Result<int>> GetTotalKanbanBoardCountAsync()
        {
            var result = await _kanbanCrudService.GetAllAsync();

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
