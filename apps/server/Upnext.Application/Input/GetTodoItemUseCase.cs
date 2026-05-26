using Mediator;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Input;

public static class GetTodoItemUseCase
{
    // TODO: Return TodoItemContract instead of the domain model
    public record Request : IRequest<Result<TodoItem>>
    {
        public required TodoItemId TodoItemId { get; set; }
    }
}