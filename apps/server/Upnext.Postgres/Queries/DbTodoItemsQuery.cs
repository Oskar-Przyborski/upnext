using Microsoft.EntityFrameworkCore;
using Upnext.Application.Output;
using Upnext.Contracts;
using Upnext.Domain;

namespace Upnext.Postgres.Queries;

public class DbTodoItemsQuery(
    AppDbContext dbContext) : ITodoItemsQuery
{
    public async Task<ListDto<TodoItemDto>> GetAsync(
        string query,
        int skip,
        int take,
        CancellationToken ct = default)
    {
        var queryable = dbContext.TodoItems.AsNoTracking();
        queryable = ApplyQuery(queryable, query);

        var count = await queryable.CountAsync(ct);
        var items = await queryable
            .Skip(skip)
            .Take(take)
            .Select(entity => new TodoItemDto
            {
                Id = entity.Id.Value,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Name = entity.Name.Value,
                Description = entity.Description.Value,
                DueDate = entity.DueDate,
                Priority = (int)entity.Priority,
                Status = (int)entity.Status
            })
            .ToListAsync(ct);

        return new ListDto<TodoItemDto>
        {
            Count = count,
            Items = items,
        };
    }

    private IQueryable<TodoItem> ApplyQuery(IQueryable<TodoItem> queryable, string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return queryable;

        return queryable.Where(item => ((string)item.Name).Contains(query)
                                       || ((string)item.Description).Contains(query));
    }
}