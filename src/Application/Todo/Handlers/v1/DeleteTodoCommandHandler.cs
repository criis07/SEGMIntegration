using lafise.test.Application.Common.Interfaces;
using lafise.test.Application.Todo.Commands.v1;
using LAFISE.CrossCutting.Core.Exceptions;
using MediatR;

namespace lafise.test.Application.Todo.Handlers.v1
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoService _todoService;

        public DeleteTodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todoToUpdate = await _todoService.GetTodoById(request.Id);

            if (todoToUpdate is null)
                throw new NotFoundException($"The todo with id {request.Id} doesn't exist");

            return await _todoService.DeleteTodo(request.Id);
        }
    }
}
