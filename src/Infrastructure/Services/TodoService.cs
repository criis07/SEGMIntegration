using lafise.test.Application.Common.Interfaces;
using lafise.test.Domain.Entities.Todos;

namespace lafise.test.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private List<TodoEntity> Todos = new List<TodoEntity>()
        {
            new TodoEntity { Id = 1, Description = "First todo description", Name = "My first todo", Version = 1.0f },
            new TodoEntity { Id = 2, Description = "Second todo description", Name = "My second todo", Version = 1.0f },
            new TodoEntity { Id = 3, Description = "Third todo description", Name = "My third todo", Version = 1.0f },
        };

        /*
         * ALL THIS METHODS SHOULDNT BE ASYNC TASKS
         * JUST TO SHOW HOW IS NORMALLY IN REAL SERVICES IMPLEMENTATIONS
        */

        public async Task<TodoEntity> CreateTodo(TodoEntity todo)
        {
            await Task.Delay(0);
            var lastItem = Todos.Last();
            todo.Id = lastItem.Id + 1;
            Todos.Add(todo);

            return todo;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todoToRemove = await GetTodoById(id);
            Todos.RemoveAt(Todos.IndexOf(todoToRemove));
            return true;
        }

        public async Task<TodoEntity> GetTodoById(int id)
        {
            await Task.Delay(1);
            return Todos.FirstOrDefault(todo => todo.Id == id)!;
        }

        public async Task<List<TodoEntity>> GetTodos()
        {
            await Task.Delay(1);
            return Todos;
        }

        public async Task<TodoEntity> UpdateTodo(int id, TodoEntity todo)
        {
            await Task.Delay(1);
            var todoToUpdate = Todos.FirstOrDefault(td => td.Id == todo.Id);
            todo.Id = id;

            todoToUpdate!.Description = todo.Description;
            todoToUpdate.Name = todo.Name;
            todoToUpdate.Version = todo.Version;
            return todo;
        }
    }
}