using Core.CrossCuttingConcerns.ExceptionHandlers.Handler;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.ExceptionHandlers;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _exceptionHandler;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExceptionMiddleware(RequestDelegate next, HttpExceptionHandler exceptionHandler, IHttpContextAccessor httpContextAccessor)
    {
        _next = next;
        _exceptionHandler = exceptionHandler;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext.Response, e);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        
        _exceptionHandler.Response = response;
        
        return _exceptionHandler.HandleExceptionAsync(exception);
    }
}