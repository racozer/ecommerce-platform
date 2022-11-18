using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Platform.Api.Core.ApplicationRunner;

public class ApiRunner
{
    public static void RunApi<TStartup>() where TStartup : class
    {
        var app = WebHost.CreateDefaultBuilder().UseStartup<TStartup>().Build();

        app.Run();
    }
}
