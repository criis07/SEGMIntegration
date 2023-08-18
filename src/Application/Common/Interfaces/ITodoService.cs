using lafise.test.Domain.Entities.Todos;

namespace lafise.test.Application.Common.Interfaces
{
    public interface ITodoService
    {
        /// <summary>
        /// Return all the todos
        /// </summary>
        /// <returns>The list of todos</returns>
        Task<List<TodoEntity>> GetTodos();

        /// <summary>
        /// Return a todo by id
        /// </summary>
        /// <param name="id">The todo id</param>
        /// <returns>The todo</returns>
        Task<TodoEntity> GetTodoById(int id);

        /// <summary>
        /// Create a new todo
        /// </summary>
        /// <param name="todo">The new todo</param>
        /// <returns>The todo created</returns>
        Task<TodoEntity> CreateTodo(TodoEntity todo);

        /// <summary>
        /// Update an existing todo
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="id">The id of the todo to update</param>
        /// <returns>The todo updated</returns>
        Task<TodoEntity> UpdateTodo(int id, TodoEntity todo);

        /// <summary>
        /// Delete a todo by id
        /// </summary>
        /// <param name="id">The todo id to delete</param>
        /// <returns>True if deleted, false otherwise</returns>
        Task<bool> DeleteTodo(int id);
    }
}