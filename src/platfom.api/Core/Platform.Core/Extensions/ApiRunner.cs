using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Platform.Core.Extensions;

public class ApiRunner
{
    public static void RunApi<TStartup>(string[] args) where TStartup : class
    {
        try
        {
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>();
                }).Build().Run();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
