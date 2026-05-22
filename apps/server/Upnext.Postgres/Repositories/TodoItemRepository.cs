using Microsoft.EntityFrameworkCore;
using Upnext.Application.Output;
using Upnext.Domain;

namespace Upnext.Postgres.Repositories;

public class TodoItemRepository(
    AppDbContext dbContext) : ITodoItemRepository
{
    public void Add(TodoItem todoItem)
    {
        dbContext.TodoItems.Add(todoItem);
    }

    public void Remove(TodoItem todoItem)
    {
        dbContext.TodoItems.Remove(todoItem);
    }

    public Task<TodoItem?> GetByIdAsync(TodoItemId id, CancellationToken cancellationToken = default)
    {
        return dbContext.TodoItems
            .Where(item => item.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
}