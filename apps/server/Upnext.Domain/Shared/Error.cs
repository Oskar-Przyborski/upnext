namespace Upnext.Domain.Shared;

public record Error(string Code, string Description, ErrorKind Kind)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorKind.None);
    
    public static Error Validation(string code, string description) => 
        new(code, description, ErrorKind.Validation);
    
    public static Error NotFound(string code, string description) => 
        new(code, description, ErrorKind.NotFound);
}