using Upnext.Domain.Shared;

namespace Upnext.Domain;

public record TaskName
{
    public const int MaxLength = 120;
    public string Value { get; }

    private TaskName(string value) => Value = value;

    public static Result<TaskName> Create(string? value)
    {
        var trimmed = value?.Trim();

        if (string.IsNullOrWhiteSpace(trimmed))
            return Result<TaskName>.Failure(TaskErrors.NameRequired);

        if (trimmed.Length > MaxLength)
            return Result<TaskName>.Failure(TaskErrors.NameTooLong);

        return Result<TaskName>.Success(new TaskName(trimmed));
    }
}