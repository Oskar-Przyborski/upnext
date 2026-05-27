using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Contracts;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class GetTodoItemUseCaseHandler(
    ITodoItemQuery todoItemQuery) : IRequestHandler<GetTodoItemUseCase.Request, Result<TodoItemDto>>
{
    public async ValueTask<Result<TodoItemDto>> Handle(
        GetTodoItemUseCase.Request request,
        CancellationToken cancellationToken)
    {
        var item = await todoItemQuery.GetAsync(request.TodoItemId, cancellationToken);
        if (item is null) return Result.Failure<TodoItemDto>(TodoItemErrors.NotFound(request.TodoItemId));

        return item;
    }
}