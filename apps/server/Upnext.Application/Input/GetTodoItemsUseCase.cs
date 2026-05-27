using Mediator;
using Upnext.Contracts;
using Upnext.Domain.Shared;

namespace Upnext.Application.Input;

public class GetTodoItemsUseCase
{
    public record Request : IRequest<Result<ListDto<TodoItemDto>>>
    {
        public string Query { get; set; } = string.Empty;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = int.MaxValue;
    }
}