namespace Upnext.Contracts;

public record TodoItemDto
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime DueDate { get; set; }
    public required int Priority { get; set; }
    public required int Status { get; set; }
}