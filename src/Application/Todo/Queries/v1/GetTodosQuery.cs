using lafise.test.Application.Todo.Dto.v1;
using MediatR;

namespace lafise.test.Application.Todo.Queries.v1
{
    public class GetTodosQuery : IRequest<List<TodoDto>>
    {
    }
}