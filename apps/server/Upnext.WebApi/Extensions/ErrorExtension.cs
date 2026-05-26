using Microsoft.AspNetCore.Mvc;
using Upnext.Domain.Shared;

namespace Upnext.WebApi.Extensions;


public static class ErrorExtension
{
    public static ActionResult ToActionResult(this Error error)
    {
        var statusCode = error.Kind switch
        {
            ErrorKind.Validation => StatusCodes.Status400BadRequest,
            ErrorKind.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorKind.Forbidden => StatusCodes.Status403Forbidden,
            ErrorKind.NotFound => StatusCodes.Status404NotFound,
            ErrorKind.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var errorObject = new ProblemDetails
        {
            Status = statusCode,
            Type = error.Code.ToLowerInvariant(),
            Detail = error.Description
        };

        return new ObjectResult(errorObject)
        {
            StatusCode = statusCode
        };
    }
}