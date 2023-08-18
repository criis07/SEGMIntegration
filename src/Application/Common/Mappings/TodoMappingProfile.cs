using AutoMapper;
using lafise.test.Application.Todo.Commands.v1;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Domain.Entities.Todos;
using LAFISE.CrossCutting.Core.Interfaces;

namespace lafise.test.Application.Common.Mappings
{
    public class TodoMappingProfile : IMapFrom<TodoEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoDto, TodoEntity>()
                .ReverseMap();

            profile.CreateMap<CreateTodoCommand, TodoEntity>()
                .ForMember(ct => ct.Id, m => m.Ignore())
                .ReverseMap();

            profile.CreateMap<UpdateTodoCommand, TodoEntity>()
                .ReverseMap();
        }
    }
}
