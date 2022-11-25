using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace Platform.Api.Core.ApplicationRunner;

public class ApiRunner
{
    public static void RunApi<TStartup>() where TStartup : class
    {
		try
		{
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder();

            builder.ConfigureServices(s => s.AddHttpContextAccessor());

            var app = builder.UseStartup<TStartup>();

            app.Build().Run();
        }
        catch (Exception ex)
		{
            throw;
		}
    }
}
