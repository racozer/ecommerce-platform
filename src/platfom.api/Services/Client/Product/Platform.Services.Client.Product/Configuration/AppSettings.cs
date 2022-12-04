namespace Platform.Services.Client.Product.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string SQLServer { get; set; }
}
