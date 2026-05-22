using Upnext.Domain;

namespace Upnext.Application.Output;

public interface ITodoItemRepository
{
    public void Add(TodoItem todoItem);
    public void Remove(TodoItem todoItem);

    public Task<TodoItem?> GetByIdAsync(TodoItemId id, CancellationToken cancellationToken = default);
}