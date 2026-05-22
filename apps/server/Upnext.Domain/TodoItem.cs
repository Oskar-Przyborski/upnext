namespace Upnext.Domain;

public class TodoItem
{
    public TodoItemId Id { get; private init; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public TodoItemName Name { get; private set; }
    public TodoItemDescription Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public TodoItemStatus Status { get; private set; }
    public TodoItemPriority Priority { get; private set; }

    private TodoItem(
        TodoItemId id,
        DateTime createdAt,
        DateTime updatedAt,
        TodoItemName name,
        TodoItemDescription description,
        DateTime dueDate,
        TodoItemStatus status,
        TodoItemPriority priority)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Name = name;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
    }


    public void SetName(TodoItemName name, DateTime now)
    {
        Name = name;
        UpdatedAt = now;
    }

    public void SetDescription(TodoItemDescription description, DateTime now)
    {
        Description = description;
        UpdatedAt = now;
    }

    public void SetDueDate(DateTime dueDate, DateTime now)
    {
        DueDate = dueDate;
    }

    public void SetStatus(TodoItemStatus status, DateTime now)
    {
        Status = status;
        UpdatedAt = now;
    }

    public void SetPriority(TodoItemPriority priority, DateTime now)
    {
        Priority = priority;
        UpdatedAt = now;
    }

    public static TodoItem Create(
        DateTime now,
        TodoItemName name,
        TodoItemDescription description,
        DateTime dueDate,
        TodoItemStatus status,
        TodoItemPriority priority)
    {
        return new TodoItem(
            id: TodoItemId.New(),
            createdAt: now,
            updatedAt: now,
            name: name,
            description: description,
            dueDate: dueDate,
            status: status,
            priority: priority);
    }
}