using AutoMapper;
using lafise.test.Application.Common.Interfaces;
using lafise.test.Application.Todo.Commands.v1;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Domain.Entities.Todos;
using MediatR;

namespace lafise.test.Application.Todo.Handlers.v1
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var response = await _todoService.CreateTodo(_mapper.Map<TodoEntity>(request));

            return _mapper.Map<TodoDto>(response);
        }
    }
}