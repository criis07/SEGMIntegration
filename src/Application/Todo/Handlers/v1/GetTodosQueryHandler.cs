using AutoMapper;
using lafise.test.Application.Common.Interfaces;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Application.Todo.Queries.v1;
using MediatR;

namespace lafise.test.Application.Todo.Handlers.v1
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoDto>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<List<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoService.GetTodos();

            return _mapper.Map<List<TodoDto>>(todos);
        }
    }
}