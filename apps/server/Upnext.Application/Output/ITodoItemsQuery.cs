using Upnext.Contracts;

namespace Upnext.Application.Output;

public interface ITodoItemsQuery
{
    public Task<ListDto<TodoItemDto>> GetAsync(
        string query,
        int skip,
        int take,
        CancellationToken ct = default);
}