using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Platform.Api.Core.BuildingBlocks.Models.Response;
using Platform.Api.Services.Client.Product.DTOs;
using Platform.Api.Services.Client.Product.Services.Abstractions;


namespace Platform.Api.Services.Client.Product.Controllers.V1;

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
    [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
    public async Task<ApplicationResponse> GetAllCategory()
    {
        return new ApplicationResponse()
        {
            Result = true,
            Payload = await _categoryService.GetAllCategory()
        };
    }

    [HttpGet("get-category-by-id")]
    [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
    public async Task<ApplicationResponse> GetCategoryById([FromQuery] long categoryId)
    {
        return new ApplicationResponse()
        {
            Result = true,
            Payload = await _categoryService.GetCategoryById(categoryId)
        };
    }

    [HttpGet("get-all-with-sub-categories")]
    [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
    public async Task<ApplicationResponse> GetAllCategoryWithSubs()
    {
        return new ApplicationResponse()
        {
            Result = true,
            Payload = await _categoryService.GetAllCategoryWithSubs()
        };
    }

    [HttpPost("add-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApplicationResponse> AddCategory([FromBody] CategoryDto categoryRequest)
    {
        await _categoryService.AddCategory(categoryRequest);

        return new ApplicationResponse() { Result = true };
    }

    [HttpPut("update-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApplicationResponse> UpdateCategory([FromBody] CategoryDto categoryRequest)
    {
        await _categoryService.UpdateCategory(categoryRequest);

        return new ApplicationResponse() { Result = true };
    }

    [HttpDelete("delete-category")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ApplicationResponse> DeleteCategory([FromBody] long id)
    {
        await _categoryService.DeleteCategory(id);

        return new ApplicationResponse() { Result = true };
    }
}
