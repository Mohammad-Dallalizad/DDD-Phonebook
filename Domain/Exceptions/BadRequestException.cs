using ApplicationCore.Enums;
using System.Net;

namespace ApplicationCore.Exceptions;

public sealed class BadRequestException : BaseWebApiException
{
    public BadRequestException(string message = "Bad Request", object? additionalData = null)
       : base(message, HttpStatusCode.BadRequest, ApiResultBodyCode.BadRequest, additionalData)
    {
    }
}
