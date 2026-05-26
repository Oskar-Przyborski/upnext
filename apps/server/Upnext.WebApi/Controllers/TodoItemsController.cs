using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Upnext.Application.Input;
using Upnext.Domain;
using Upnext.WebApi.Bodies;
using Upnext.WebApi.Extensions;

namespace Upnext.WebApi.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("v{v:apiVersion}/[controller]")]
public class TodoItemsController(
    ISender sender) : ControllerBase
{
    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTodoItemBody body,
        CancellationToken ct)
    {
        var name = TodoItemName.Create(body.Name);
        if (!name.IsSuccess) return name.Error.ToActionResult();

        var description = TodoItemDescription.Create(body.Description);
        if (!description.IsSuccess) return description.Error.ToActionResult();

        var request = new CreateTodoItemUseCase.Request
        {
            Name = name.Value,
            Description = description.Value,
            DueDate = body.DueDate ?? DateTime.UtcNow,
            Priority = body.Priority ?? TodoItemPriority.Medium,
            Status = body.Status ?? TodoItemStatus.ToDo,
        };

        var response = await sender.Send(request, ct);
        if (!response.IsSuccess) response.Error.ToActionResult();

        return Ok(response.Value.Value);
    }
   
    [MapToApiVersion(1)]
    [HttpGet("{todoItemId:guid}")]
    public async Task<ActionResult<TodoItem>> GetItem(
        [FromRoute] Guid todoItemId,
        CancellationToken ct)
    {
        var request = new GetTodoItemUseCase.Request
        {
            TodoItemId = TodoItemId.From(todoItemId),
        };

        var response = await sender.Send(request, ct);
        if (!response.IsSuccess) return response.Error.ToActionResult();

        return Ok(response.Value);
    }
    
    [MapToApiVersion(1)]
    [HttpPut("{todoItemId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid todoItemId,
        [FromBody] UpdateTodoItemBody body,
        CancellationToken ct)
    {
        var name = TodoItemName.Create(body.Name);
        if (!name.IsSuccess) return name.Error.ToActionResult();

        var description = TodoItemDescription.Create(body.Description);
        if (!description.IsSuccess) return description.Error.ToActionResult();

        var request = new UpdateTodoItemUseCase.Request
        {
            TodoItemId = TodoItemId.From(todoItemId),
            Name = name.Value,
            Description = description.Value,
            DueDate = body.DueDate,
            Priority = body.Priority,
            Status = body.Status,
        };

        var response = await sender.Send(request, ct);
        if (!response.IsSuccess) return response.Error.ToActionResult();

        return NoContent();
    }
}