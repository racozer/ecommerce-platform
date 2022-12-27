using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Platform.Core.Models.Response;
using Platform.Services.Client.Product.DTOs;
using Platform.Services.Client.Product.Services.Abstractions;


namespace Platform.Services.Client.Product.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class ProductBrandController : ControllerBase
{
    private readonly IProductBrandService _productBrandService;


    public ProductBrandController(IProductBrandService productBrandService)
    {
        _productBrandService = productBrandService;
    }


    [HttpGet("get-brand-by-id")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<ApiResponse> GetBrandById([FromQuery] long brandId)
    {
        return new ApiResponse()
        {
            Result = true,
            Payload = await _productBrandService.GetBrandById(brandId)
        };
    }

    [HttpGet("get-all-brand")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<ApiResponse> GetAllBrand()
    {
        return new ApiResponse()
        {
            Result = true,
            Payload = await _productBrandService.GetAllBrand()
        };
    }

    [HttpPost("add-brand")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> AddBrand([FromBody] ProductBrandDto request)
    {
        await _productBrandService.AddBrand(request);

        return new ApiResponse() { Result = true };
    }

    [HttpPut("update-brand")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> UpdateBrand([FromBody] ProductBrandDto request)
    {
        await _productBrandService.UpdateBrand(request);

        return new ApiResponse() { Result = true };
    }

    [HttpDelete("delete-brand")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> DeleteBrand([FromBody] long id)
    {
        await _productBrandService.DeleteBrand(id);

        return new ApiResponse() { Result = true };
    }
}