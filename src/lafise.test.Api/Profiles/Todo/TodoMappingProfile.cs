using AutoMapper;
using lafise.test.Api.Models.v1;
using lafise.test.Application.Todo.Commands.v1;

namespace lafise.test.Api.Profiles.Todo
{
    /// <summary>
    /// Class to map the different classes used in API Layer
    /// </summary>
    public class TodoMappingProfile : Profile
    {
        /// <summary>
        /// Inject all mappings here
        /// </summary>
        public TodoMappingProfile()
        {
            CreateMap<CreateTodoJson, CreateTodoCommand>();

            CreateMap<UpdateTodoJson, UpdateTodoCommand>();
        }
    }
}