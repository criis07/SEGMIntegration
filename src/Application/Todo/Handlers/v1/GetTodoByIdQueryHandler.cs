using AutoMapper;
using lafise.test.Application.Common.Interfaces;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Application.Todo.Queries.v1;
using LAFISE.CrossCutting.Core.Exceptions;
using MediatR;

namespace lafise.test.Application.Todo.Handlers.v1
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodoByIdQueryHandler(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoService.GetTodoById(request.Id);

            if (todo is null)
                throw new NotFoundException($"The todo with id {request.Id} doesn't exist");

            return _mapper.Map<TodoDto>(todo);
        }
    }
}
