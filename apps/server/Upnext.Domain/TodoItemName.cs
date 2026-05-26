using Upnext.Domain.Shared;

namespace Upnext.Domain;

public record struct TodoItemName
{
    public const int MaxLength = 120;
    public string Value { get; }

    private TodoItemName(string value) => Value = value;

    public static Result<TodoItemName> Create(string? value)
    {
        var trimmed = value?.Trim();

        if (string.IsNullOrWhiteSpace(trimmed))
            return Result.Failure<TodoItemName>(TodoItemErrors.NameRequired);

        if (trimmed.Length > MaxLength)
            return Result.Failure<TodoItemName>(TodoItemErrors.NameTooLong);

        return Result.Success(new TodoItemName(trimmed));
    }
}