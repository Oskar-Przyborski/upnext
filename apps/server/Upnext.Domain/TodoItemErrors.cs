using Upnext.Domain.Shared;

namespace Upnext.Domain;

public static class TodoItemErrors
{
    public static Error NameRequired => Error.Validation(
        "TodoItem.NameRequired", "The item name cannot be empty.");

    public static Error NameTooLong => Error.Validation(
        "TodoItem.NameTooLong", $"The item name exceeds {TodoItemName.MaxLength} characters.");

    public static Error DescriptionTooLong => Error.Validation(
        "TodoItem.DescriptionTooLong", $"The description exceeds {TodoItemDescription.MaxLength} characters.");

    public static Error NotFound(TodoItemId itemId) => Error.NotFound(
        "TodoItem.NotFound", $"The item with ID {itemId} was not found.");
}