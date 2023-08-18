using AutoMapper;
using lafise.test.Api.Filters;
using lafise.test.Api.Models.v1;
using lafise.test.Application.Todo.Commands.v1;
using lafise.test.Application.Todo.Dto.v1;
using lafise.test.Application.Todo.Queries.v1;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace lafise.test.Api.Controllers.v1
{
    /// <summary>
    /// Controller that manage all the To Do requests
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class ToDoControlerController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor used to inject different services
        /// </summary>
        /// <param name="mapper"></param>
        public ToDoControlerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a Todo
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Creates a new Todo and returns the new Todo
        /// .&lt;/p&gt;&lt;p&gt;Authentication is Mandatory&lt;/p&gt;
        /// </remarks>
        /// <param name="BODY">The data contract structure from the client</param>
        [MapToApiVersion("1.0")]
        [HttpPost("todos")]
        [ProducesResponseType(typeof(TodoDto), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [SwaggerOperation(Tags = new[] { "Todos Manipulation" })]
        [ValidateModelState]
        public virtual async Task<IActionResult> CreateToDoAsync([FromBody][Required] CreateTodoJson BODY)
        {
            var result = await Mediator.Send(_mapper.Map<CreateTodoCommand>(BODY));
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Updates a Todo
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Update an existing Todo and returns the updated Todo
        /// .&lt;/p&gt;&lt;p&gt;Authentication is Mandatory&lt;/p&gt;
        /// </remarks>
        /// <param name="BODY">The data contract structure from the client</param>
        /// <param name="TODO_ID">The id of the todo to update</param>
        [MapToApiVersion("1.0")]
        [HttpPut("todos/{TODO_ID}")]
        [ProducesResponseType(typeof(TodoDto), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [SwaggerOperation(Tags = new[] { "Todos Manipulation" })]
        [ValidateModelState]
        public virtual async Task<IActionResult> UpdateToDoAsync([FromBody][Required] UpdateTodoJson BODY, [FromRoute][Required] int TODO_ID)
        {
            var updateTodoCommand = _mapper.Map<UpdateTodoCommand>(BODY);
            updateTodoCommand.Id = TODO_ID;
            var result = await Mediator.Send(updateTodoCommand);
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Deletes a Todo
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Delete an existing Todo
        /// .&lt;/p&gt;&lt;p&gt;Authentication is Mandatory&lt;/p&gt;
        /// </remarks>
        /// <param name="TODO_ID">The id of the todo to delete</param>
        [MapToApiVersion("1.0")]
        [HttpDelete("todos/{TODO_ID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [SwaggerOperation(Tags = new[] { "Todos Manipulation" })]
        [ValidateModelState]
        public virtual async Task<IActionResult> DeleteToDoAsync([FromRoute][Required] int TODO_ID)
        {
            await Mediator.Send(new DeleteTodoCommand { Id = TODO_ID });
            return Ok();
        }

        /// <summary>
        /// Returns the list of all the todos
        /// </summary>
        /// <remarks>
        /// Return all the todos
        /// </remarks>
        [MapToApiVersion("1.0")]
        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<TodoDto>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [SwaggerOperation(Tags = new[] { "Todos Consultation" })]
        [ValidateModelState]
        public virtual async Task<IActionResult> GetTodosAsync()
        {
            return Ok(await Mediator.Send(new GetTodosQuery()));
        }

        /// <summary>
        /// Returns the todo associated to the todo id given
        /// </summary>
        /// <remarks>
        /// Returns only one todo
        /// </remarks>
        /// <param name="TODO_ID">The id of the todo to get</param>
        [MapToApiVersion("1.0")]
        [HttpGet("todos/{TODO_ID}")]
        [ProducesResponseType(typeof(TodoDto), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [SwaggerOperation(Tags = new[] { "Todos Consultation" })]
        [ValidateModelState]
        public virtual async Task<IActionResult> GetTodoByIdAsync([FromRoute][Required] int TODO_ID)
        {
            return Ok(await Mediator.Send(new GetTodoByIdQuery { Id = TODO_ID }));
        }
    }
}