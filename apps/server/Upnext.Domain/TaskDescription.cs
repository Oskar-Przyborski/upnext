using Upnext.Domain.Shared;

namespace Upnext.Domain;

public record TaskDescription
{
    public const int MaxLength = 1000;
    public string Value { get; }

    private TaskDescription(string value) => Value = value;

    public static Result<TaskDescription> Create(string? value)
    {
        var processed = value?.Trim() ?? string.Empty;

        if (processed.Length > MaxLength)
            return Result<TaskDescription>.Failure(TaskErrors.DescriptionTooLong);

        return Result<TaskDescription>.Success(new TaskDescription(processed));
    }
}