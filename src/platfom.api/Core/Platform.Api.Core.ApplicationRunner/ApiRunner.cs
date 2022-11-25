using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Platform.Api.Core.ApplicationRunner;

public class ApiRunner
{
    public static void RunApi<TStartup>() where TStartup : class
    {
		try
		{
            var builder = WebHost.CreateDefaultBuilder();

            var app = builder.UseStartup<TStartup>();

            app.Build().Run();
        }
        catch (Exception ex)
		{
            throw;
		}
    }
}
