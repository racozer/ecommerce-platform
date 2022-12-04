using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Platform.Core.Exceptions;
using Platform.Core.Models.Response;


namespace Platform.Infrastructure.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;


    public ExceptionHandlerMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlerMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException ex)
        {
            _logger.LogWarning("Got an exception: {Exception}", ex.Message);
            await handleBaseExceptionsAsync(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("An unexpected error occured: {Exception}", ex);
            await handleUnknownExceptionsAsync(context, ex);
        }
    }

    private async Task handleUnknownExceptionsAsync(HttpContext context, Exception ex)
    {
        var response = new ApiResponse
        {
            Message = "An unexpected error occured",
            Result = false
        };

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(response);
    }

    private async Task handleBaseExceptionsAsync(HttpContext context, BaseException ex)
    {
        var response = new ApiResponse
        {
            Message = ex.Message,
            Result = false
        };

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(response);
    }
}
