using lafise.test.Application.Todo.Dto.v1;
using MediatR;

namespace lafise.test.Application.Todo.Commands.v1
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public float Version { get; set; }
    }
}