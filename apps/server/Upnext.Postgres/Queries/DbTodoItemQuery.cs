using Microsoft.EntityFrameworkCore;
using Upnext.Application.Output;
using Upnext.Contracts;
using Upnext.Domain;

namespace Upnext.Postgres.Queries;

public class DbTodoItemQuery(
    AppDbContext dbContext) : ITodoItemQuery
{
    public Task<TodoItemDto?> GetAsync(TodoItemId id, CancellationToken ct = default)
    {
        return dbContext.TodoItems
            .AsNoTracking()
            .Where(item => item.Id == id)
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
            .SingleOrDefaultAsync(ct);
    }
}