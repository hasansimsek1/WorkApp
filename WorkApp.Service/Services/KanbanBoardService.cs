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

        public async Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoard()
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

        public async Task<Result<int>> GetTotalKanbanBoardCount()
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
