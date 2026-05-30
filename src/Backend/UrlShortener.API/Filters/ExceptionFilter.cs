using CARL.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UrlShortener.Exceptions;
using UrlShortener.Exceptions.ExceptionsBase;

namespace UrlShortener.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is UrlShortenerException urlShortenerException)
            HandleProjectException(urlShortenerException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(UrlShortenerException urlShortenerException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)urlShortenerException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(urlShortenerException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
    }
}
