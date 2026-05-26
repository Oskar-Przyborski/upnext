using Upnext.Domain.Shared;

namespace Upnext.Domain;

public record struct TodoItemDescription
{
    public const int MaxLength = 1000;
    public string Value { get; }

    private TodoItemDescription(string value) => Value = value;

    public static Result<TodoItemDescription> Create(string? value)
    {
        var processed = value?.Trim() ?? string.Empty;

        if (processed.Length > MaxLength)
        {
            return Result.Failure<TodoItemDescription>(TodoItemErrors.DescriptionTooLong);
        }

        return Result.Success(new TodoItemDescription(processed));
    }
    
    public static TodoItemDescription Empty => Create("").Value;
}