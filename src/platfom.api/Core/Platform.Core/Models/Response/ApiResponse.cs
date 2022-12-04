namespace Platform.Core.Models.Response;

public class ApiResponse<T>
{
    public T? Payload { get; set; }
    public bool Result { get; set; }
    public string? Message { get; set; }
}

public class ApiResponse
{
    public object? Payload { get; set; }
    public bool Result { get; set; }
    public string? Message { get; set; }
}