using Platform.Api.Core.ApplicationRunner;


namespace Platform.Api.Services.Client.Product;

public class Program
{
    public static void Main()
    {
        ApiRunner.RunApi<Startup>();
    }
}
