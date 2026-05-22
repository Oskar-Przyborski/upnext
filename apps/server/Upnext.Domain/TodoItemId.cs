namespace Upnext.Domain;

public record struct TodoItemId(Guid Value)
{
    public override string ToString() => Value.ToString();
    
    public static TodoItemId New() => new(Guid.NewGuid());
    public static TodoItemId From(Guid value) => new(value);
}