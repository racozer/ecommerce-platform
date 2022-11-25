using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Platform.Api.Core.BuildingBlocks.Middlewares;

public class HttpStatusLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HttpStatusLoggerMiddleware> _logger;

    public HttpStatusLoggerMiddleware(RequestDelegate next, 
        ILogger<HttpStatusLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        var code = context.Response.StatusCode;
        var path = context.Request.Path;
        var method = context.Request.Method;

        var userId = context.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value ?? context.User.FindFirst("sub")?.Value;

        var remoteIp = context.Connection.RemoteIpAddress;

        var statusCodes = new[] { StatusCodes.Status401Unauthorized, StatusCodes.Status403Forbidden };

        if (statusCodes.Contains(code))
            _logger.LogWarning($"StatusCode: {code}, UserId: {userId}, Path: {path}, Method: {method}, IP: {remoteIp}");
        else
        {
            _logger.LogInformation($"StatusCode: {code}, UserId: {userId}, Path: {path}, Method: {method}, IP: {remoteIp}");
        }
    }
}
