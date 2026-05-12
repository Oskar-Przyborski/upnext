namespace Upnext.Domain.Shared;

public enum ErrorKind
{
    None = 0,
    Validation = 1,      // Maps to 400 Bad Request
    NotFound = 2,        // Maps to 404 Not Found
    Conflict = 3,        // Maps to 409 Conflict
    Unauthorized = 4,    // Maps to 401 Unauthorized
    Forbidden = 5,       // Maps to 403 Forbidden
    InternalFailure = 6  // Maps to 500 Internal Server Error
}