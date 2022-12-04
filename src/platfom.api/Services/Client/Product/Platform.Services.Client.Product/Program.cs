using Platform.Core.Extensions;


namespace Platform.Services.Client.Product;

public class Program
{
    public static void Main(string[] args)
    {
        ApiRunner.RunApi<Startup>(args);
    }
}
