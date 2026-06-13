using TodoApi.Models;

namespace TodoApi.Repositories;

public interface ITodoRepository
{
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(int id);
    TodoItem Add(TodoItem item);
    TodoItem? Update(int id, TodoItem item);
    bool Delete(int id);
}
