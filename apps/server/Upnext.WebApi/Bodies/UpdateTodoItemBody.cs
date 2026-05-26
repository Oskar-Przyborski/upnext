using Upnext.Domain;

namespace Upnext.WebApi.Bodies;

public record UpdateTodoItemBody
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime DueDate { get; set; }
    public required TodoItemPriority Priority { get; set; }
    public required TodoItemStatus Status { get; set; }
}