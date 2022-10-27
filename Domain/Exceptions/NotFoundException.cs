using ApplicationCore.Enums;
using System.Net;

namespace ApplicationCore.Exceptions;

public sealed class NotFoundException : BaseWebApiException
{
    public NotFoundException(string message = "Not found", object? additionalData = null)
       : base(message, HttpStatusCode.NotFound, ApiResultBodyCode.NotFound, additionalData)
    {
    }
}
