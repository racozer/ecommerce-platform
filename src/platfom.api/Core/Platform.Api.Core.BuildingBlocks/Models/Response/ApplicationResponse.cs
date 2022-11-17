namespace Platform.Api.Core.BuildingBlocks.Models.Response;

public class ApplicationResponse<T>
{
    public T? Payload { get; set; }
    public bool Result { get; set; }
    public string? Message { get; set; }
}

public class ApplicationResponse
{
    public object? Payload { get; set; }
    public bool Result { get; set; }
    public string? Message { get; set; }
}
