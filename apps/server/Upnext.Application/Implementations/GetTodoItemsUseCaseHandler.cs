using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Contracts;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class GetTodoItemsUseCaseHandler(
    ITodoItemsQuery todoItemsQuery) : IRequestHandler<GetTodoItemsUseCase.Request, Result<ListDto<TodoItemDto>>>
{
    public async ValueTask<Result<ListDto<TodoItemDto>>> Handle(
        GetTodoItemsUseCase.Request request,
        CancellationToken cancellationToken)
    {
        return await todoItemsQuery.GetAsync(
            request.Query,
            request.Skip,
            request.Take,
            cancellationToken);
    }
}