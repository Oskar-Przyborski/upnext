using Upnext.Domain;

namespace Upnext.WebApi.Bodies;

public record CreateTodoItemBody
{
    public required string Name { get; set; }
    public string? Description { get; set; } = null;
    public DateTime? DueDate { get; set; } = null;
    public TodoItemPriority? Priority { get; set; } = null;
    public TodoItemStatus? Status { get; set; } = null;
}