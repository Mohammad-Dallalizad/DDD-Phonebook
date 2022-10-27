using ApplicationCore.Enums;
using System.Net;

namespace ApplicationCore.Exceptions;

public sealed class DuplicateException : BaseWebApiException
{
    public DuplicateException(string message = "Duplication", object? additionalData = null)
       : base(message, HttpStatusCode.Conflict, ApiResultBodyCode.Duplication, additionalData)
    {
    }
}
