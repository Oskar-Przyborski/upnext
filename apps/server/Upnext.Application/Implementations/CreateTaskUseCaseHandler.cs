using Mediator;
using Upnext.Application.Input;
using Upnext.Application.Output;
using Upnext.Domain;
using Upnext.Domain.Shared;

namespace Upnext.Application.Implementations;

public class CreateTaskUseCaseHandler(
    TimeProvider clock,
    ITodoItemRepository todoItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateTodoItemUseCase.Request, Result<TodoItemId>>
{
    public async ValueTask<Result<TodoItemId>> Handle(
        CreateTodoItemUseCase.Request request,
        CancellationToken cancellationToken)
    {
        var now = clock.GetUtcNow();

        var create = TodoItem.Create(
            now: now.DateTime,
            name: request.Name,
            description: request.Description,
            dueDate: request.DueDate,
            status: request.Status,
            priority: request.Priority);
        
        todoItemRepository.Add(create);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(create.Id);
    }
}