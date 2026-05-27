using Mediator;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Input;

public static class DeleteTodoItemUseCase
{
    public record Request : IRequest<Result>
    {
        public required TodoItemId TodoItemId { get; set; }
    }
}