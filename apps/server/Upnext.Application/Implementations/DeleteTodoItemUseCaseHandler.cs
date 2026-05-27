using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class DeleteTodoItemUseCaseHandler(
    ITodoItemRepository todoItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteTodoItemUseCase.Request, Result>
{
    public async ValueTask<Result> Handle(
        DeleteTodoItemUseCase.Request request,
        CancellationToken cancellationToken)
    {
        var todoItem = await todoItemRepository.GetByIdAsync(request.TodoItemId, cancellationToken);
        if (todoItem is null) return Result.Failure(TodoItemErrors.NotFound(request.TodoItemId));

        todoItemRepository.Remove(todoItem);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}