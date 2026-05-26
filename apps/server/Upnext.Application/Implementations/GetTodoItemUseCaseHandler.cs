using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class GetTodoItemUseCaseHandler(
    ITodoItemRepository repository) : IRequestHandler<GetTodoItemUseCase.Request, Result<TodoItem>>
{
    public async ValueTask<Result<TodoItem>> Handle(
        GetTodoItemUseCase.Request request,
        CancellationToken cancellationToken)
    {
        var item = await repository.GetByIdAsync(request.TodoItemId, cancellationToken);
        if (item is null) return Result.Failure<TodoItem>(TodoItemErrors.NotFound(request.TodoItemId));

        return item;
    }
}