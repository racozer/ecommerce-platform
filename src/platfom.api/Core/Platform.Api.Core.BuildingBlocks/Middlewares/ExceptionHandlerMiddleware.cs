using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Platform.Api.Core.BuildingBlocks.Exceptions;
using Platform.Api.Core.BuildingBlocks.Models.Response;


namespace Platform.Api.Core.BuildingBlocks.Middlewares;

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
        catch (ProblemBaseException ex)
        {
            _logger.LogWarning("Got an exception: {Exception}", ex.Message);
            await this.handleBaseExceptionsAsync(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("An unexpected error occured: {Exception}", ex);
            await this.handleUnknownExceptionsAsync(context, ex);
        }
    }

    private async Task handleUnknownExceptionsAsync(HttpContext context, Exception ex)
    {
        var response = new ApplicationResponse
        {
            Message = "An unexpected error occured",
            Result = false
        };

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(response);
    }

    private async Task handleBaseExceptionsAsync(HttpContext context, ProblemBaseException ex)
    {
        var response = new ApplicationResponse
        {
            Message = ex.Message,
            Result = false
        };

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(response);
    }
}
