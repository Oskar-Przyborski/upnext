using Mediator;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Input;

public static class UpdateTodoItemUseCase
{
    public record Request : IRequest<Result>
    {
        public required TodoItemId TodoItemId { get; set; }
        public TodoItemName? Name { get; set; } 
        public TodoItemDescription? Description { get; set; } 
        public DateTime? DueDate { get; set; } 
        public TodoItemStatus? Status { get; set; } 
        public TodoItemPriority? Priority { get; set; } 
    }
}