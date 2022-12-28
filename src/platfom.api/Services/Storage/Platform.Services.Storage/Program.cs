using Platform.Core.Extensions;
using Platform.Services.Storage;


namespace Platform.Services.Storge;

public class Program
{
    public static void Main(string[] args)
    {
        ApiRunner.RunApi<Startup>(args);
    }
}
