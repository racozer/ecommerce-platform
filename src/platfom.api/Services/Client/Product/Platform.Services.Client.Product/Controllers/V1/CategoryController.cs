using Microsoft.AspNetCore.Mvc;
using Platform.Core.Models.Response;
using Platform.Services.Client.Product.DTOs;
using Platform.Services.Client.Product.Services.Abstractions;
using System.Net.Mime;


namespace Platform.Services.Client.Product.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;


    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("get-all-category")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<ApiResponse> GetAllCategory()
    {
        return new ApiResponse()
        {
            Result = true,
            Payload = await _categoryService.GetAllCategory()
        };
    }

    [HttpGet("get-category-by-id")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<ApiResponse> GetCategoryById([FromQuery] long categoryId)
    {
        return new ApiResponse()
        {
            Result = true,
            Payload = await _categoryService.GetCategoryById(categoryId)
        };
    }

    [HttpGet("get-all-with-sub-categories")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<ApiResponse> GetAllCategoryWithSubs()
    {
        return new ApiResponse()
        {
            Result = true,
            Payload = await _categoryService.GetAllCategoryWithSubs()
        };
    }

    [HttpPost("add-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> AddCategory([FromBody] CategoryDto categoryRequest)
    {
        await _categoryService.AddCategory(categoryRequest);

        return new ApiResponse() { Result = true };
    }

    [HttpPut("update-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> UpdateCategory([FromBody] CategoryDto categoryRequest)
    {
        await _categoryService.UpdateCategory(categoryRequest);

        return new ApiResponse() { Result = true };
    }

    [HttpDelete("delete-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApiResponse> DeleteCategory([FromBody] long id)
    {
        await _categoryService.DeleteCategory(id);

        return new ApiResponse() { Result = true };
    }
}
