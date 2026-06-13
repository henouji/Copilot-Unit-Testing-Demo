using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _items = new();
    private readonly object _lock = new();
    private int _nextId = 1;

    public IEnumerable<TodoItem> GetAll()
    {
        lock (_lock)
        {
            return _items.ToList();
        }
    }

    public TodoItem? GetById(int id)
    {
        lock (_lock)
        {
            return _items.FirstOrDefault(t => t.Id == id);
        }
    }

    public TodoItem Add(TodoItem item)
    {
        lock (_lock)
        {
            item.Id = _nextId++;
            item.CreatedAt = DateTime.UtcNow;
            _items.Add(item);
            return item;
        }
    }

    public TodoItem? Update(int id, TodoItem updatedItem)
    {
        lock (_lock)
        {
            var existing = _items.FirstOrDefault(t => t.Id == id);
            if (existing is null)
                return null;

            existing.Title = updatedItem.Title;
            existing.Description = updatedItem.Description;

            if (!existing.IsCompleted && updatedItem.IsCompleted)
                existing.CompletedAt = DateTime.UtcNow;
            else if (existing.IsCompleted && !updatedItem.IsCompleted)
                existing.CompletedAt = null;

            existing.IsCompleted = updatedItem.IsCompleted;

            return existing;
        }
    }

    public bool Delete(int id)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(t => t.Id == id);
            if (item is null)
                return false;

            _items.Remove(item);
            return true;
        }
    }
}
