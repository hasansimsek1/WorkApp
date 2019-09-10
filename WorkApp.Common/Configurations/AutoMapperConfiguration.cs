using AutoMapper;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Entities;

namespace WorkApp.Common.Configurations
{
    /// <summary>
    /// Configurations for AutoMapper.
    /// </summary>
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var autoMapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<AutoMapperMappings>();
            });

            return autoMapperConfig;
        }
    }

    /// <summary>
    /// Profile for AutoMapper
    /// </summary>
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<DesktopMenu, DesktopMenuDto>();
            CreateMap<EntityBase, DtoBase>();
            CreateMap<KanbanBoard, KanbanBoardDto>();
            CreateMap<KanbanBoardColumn, KanbanBoardColumnDto>();
            CreateMap<KanbanBoardCard, KanbanBoardCardDto>();
            CreateMap<KanbanBoardCardTag, KanbanBoardCardTagDto>();
            CreateMap<Note, NoteDto>();
            CreateMap<NoteTag, NoteTagDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<ToDo, ToDoDto>();

            CreateMap<ApplicationUserDto, ApplicationUser>();
            CreateMap<DesktopMenuDto, DesktopMenu>();
            CreateMap<DtoBase, EntityBase>();
            CreateMap<KanbanBoardDto, KanbanBoard>();
            CreateMap<KanbanBoardColumnDto, KanbanBoardColumn>();
            CreateMap<KanbanBoardCardDto, KanbanBoardCard>();
            CreateMap<KanbanBoardCardTagDto, KanbanBoardCardTag>();
            CreateMap<NoteDto, Note>();
            CreateMap<NoteTagDto, NoteTag>();
            CreateMap<TagDto, Tag>();
            CreateMap<ToDoDto, ToDo>();
        }
    }
}
