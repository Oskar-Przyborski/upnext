using Upnext.Domain.Shared;

namespace Upnext.Domain;

public static class TaskErrors
{
    public static Error NameRequired => Error.Validation(
        "Task.NameRequired", "The task name cannot be empty.");

    public static Error NameTooLong => Error.Validation(
        "Task.NameTooLong", $"The task name exceeds {TaskName.MaxLength} characters.");

    public static Error DescriptionTooLong => Error.Validation(
        "Task.DescriptionTooLong", $"The description exceeds {TaskDescription.MaxLength} characters.");

    public static Error NotFound(Guid taskId) => Error.NotFound(
        "Task.NotFound", $"The task with ID {taskId} was not found.");
}