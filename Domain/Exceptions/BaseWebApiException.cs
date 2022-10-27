using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions;

public class BaseWebApiException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public ApiResultBodyCode ApiResultBodyCode { get; }

    public object? AdditionalData { get; set; }

    public BaseWebApiException(string? message = null, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError, ApiResultBodyCode apiResultBodyCode = ApiResultBodyCode.ServerError, object? additionalData = null)
        : base(message)
    {
        HttpStatusCode = httpStatusCode;
        ApiResultBodyCode = apiResultBodyCode;
        AdditionalData = additionalData;
    }
}
