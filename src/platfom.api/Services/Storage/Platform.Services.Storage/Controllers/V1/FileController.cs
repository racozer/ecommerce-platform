using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Platform.Core.Models.Response;


namespace Platform.Services.Storage.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class FileController : ControllerBase
{
    readonly IConfiguration _configuration;


    public FileController(IConfiguration configuration) { _configuration = configuration; }


    [HttpGet("get-storage-url")]
    public ApiResponse GetStorageURL()
    {
        return new ApiResponse { Payload = _configuration["Storages:Azure:Url"], Result = true };
    }
}