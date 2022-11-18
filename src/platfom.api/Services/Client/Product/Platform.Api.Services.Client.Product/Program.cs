using Microsoft.AspNetCore;
using Platform.Api.Core.ApplicationRunner;


namespace Platform.Api.Services.Client.Product;

public class Program
{
    public static void Main()
    {
        ApiRunner.RunApi<Startup>();
    }

/*    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }*/
}
