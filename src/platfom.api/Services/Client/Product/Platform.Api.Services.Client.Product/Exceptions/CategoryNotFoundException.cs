using Platform.Api.Core.BuildingBlocks.Exceptions;


namespace Platform.Api.Services.Client.Product.Exceptions;

public class CategoryNotFoundException : ProblemBaseException
{
    public override string Message => "Category not found";
}
