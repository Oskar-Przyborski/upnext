using Mediator;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Input;

public static class CreateTodoItemUseCase
{
    public record Request : IRequest<Result<TodoItemId>>
    {
        public required TodoItemName Name { get; set; }
        public required TodoItemDescription Description { get; set; }
        public required DateTime DueDate { get; set; }
        public required TodoItemStatus Status { get; set; }
        public required TodoItemPriority Priority { get; set; }
    }
}