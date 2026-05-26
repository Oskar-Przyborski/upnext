using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class UpdateTaskUseCaseHandler(
    TimeProvider clock,
    ITodoItemRepository todoItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateTodoItemUseCase.Request, Result>
{
    public async ValueTask<Result> Handle(
        UpdateTodoItemUseCase.Request request,
        CancellationToken cancellationToken)
    {
        var todoItem = await todoItemRepository.GetByIdAsync(request.TodoItemId, cancellationToken);
        if (todoItem is null) return Result.Failure(TodoItemErrors.NotFound(request.TodoItemId));

        var now = clock.GetUtcNow();

        if (request.Name.HasValue) todoItem.SetName(request.Name.Value, now.DateTime);
        if (request.Description.HasValue) todoItem.SetDescription(request.Description.Value, now.DateTime);
        if (request.DueDate.HasValue) todoItem.SetDueDate(request.DueDate.Value, now.DateTime);
        if (request.Status.HasValue) todoItem.SetStatus(request.Status.Value, now.DateTime);
        if (request.Priority.HasValue) todoItem.SetPriority(request.Priority.Value, now.DateTime);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}