using Upnext.Contracts;
using Upnext.Domain;

namespace Upnext.Application.Output;

public interface ITodoItemQuery
{
    public Task<TodoItemDto?> GetAsync(TodoItemId id, CancellationToken ct = default);
}