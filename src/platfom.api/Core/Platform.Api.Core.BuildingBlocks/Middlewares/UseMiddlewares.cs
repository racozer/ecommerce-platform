using Microsoft.AspNetCore.Builder;


namespace Platform.Api.Core.BuildingBlocks.Middlewares;

public static class UseMiddlewares
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    public static IApplicationBuilder UseHttpStatusLoggerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpStatusLoggerMiddleware>();
    }
}
