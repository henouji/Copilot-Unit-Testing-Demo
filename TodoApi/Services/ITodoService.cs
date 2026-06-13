using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAllTodos();
    TodoItem? GetTodoById(int id);
    TodoItem CreateTodo(string title, string? description);
    TodoItem? UpdateTodo(int id, string title, string? description, bool isCompleted);
    bool DeleteTodo(int id);
}
