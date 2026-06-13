using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TodoItem> GetAllTodos()
    {
        return _repository.GetAll();
    }

    public TodoItem? GetTodoById(int id)
    {
        return _repository.GetById(id);
    }

    public TodoItem CreateTodo(string title, string? description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        var item = new TodoItem
        {
            Title = title.Trim(),
            Description = description?.Trim(),
            IsCompleted = false
        };

        return _repository.Add(item);
    }

    public TodoItem? UpdateTodo(int id, string title, string? description, bool isCompleted)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        var updatedItem = new TodoItem
        {
            Title = title.Trim(),
            Description = description?.Trim(),
            IsCompleted = isCompleted
        };

        return _repository.Update(id, updatedItem);
    }

    public bool DeleteTodo(int id)
    {
        return _repository.Delete(id);
    }
}
