namespace Upnext.Contracts;

public record ListDto<T>
{
    public required int Count { get; set; }
    public required IReadOnlyCollection<T> Items { get; set; }
}