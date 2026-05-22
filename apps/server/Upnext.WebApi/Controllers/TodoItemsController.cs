using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Upnext.Application.Input;
using Upnext.Domain;

namespace Upnext.WebApi.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("v{v:apiVersion}/[controller]")]
public class TodoItemsController(
    ISender sender)
{
    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IResult> Create(CancellationToken ct)
    {
        var request = new CreateTodoItemUseCase.Request
        {
            Name = TodoItemName.Create("Hello, World").Value,
            Description = TodoItemDescription.Create("This is long description for my todo").Value,
            DueDate = DateTime.UtcNow,
            Priority = TodoItemPriority.Medium,
            Status = TodoItemStatus.ToDo,
        };

        var response = await sender.Send(request, ct);
        if (!response.IsSuccess) return Results.BadRequest(response.Error);

        return Results.Ok(response.Value.Value);
    }
}