using AutoMapper;
using lafise.test.Application.Common.Interfaces;
using lafise.test.Application.Todo.Commands.v1;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Domain.Entities.Todos;
using LAFISE.CrossCutting.Core.Exceptions;
using MediatR;

namespace lafise.test.Application.Todo.Handlers.v1
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public UpdateTodoCommandHandler(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoToUpdate = await _todoService.GetTodoById(request.Id);

            if (todoToUpdate is null)
                throw new NotFoundException($"The todo with id {request.Id} doesn't exist");

            var todoUpdated = await _todoService.UpdateTodo(request.Id, _mapper.Map<TodoEntity>(request));

            return _mapper.Map<TodoDto>(todoUpdated);
        }
    }
}
