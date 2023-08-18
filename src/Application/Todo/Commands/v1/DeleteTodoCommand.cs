using MediatR;

namespace lafise.test.Application.Todo.Commands.v1
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}