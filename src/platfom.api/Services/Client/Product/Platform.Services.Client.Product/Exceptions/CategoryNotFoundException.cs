using Platform.Core.Exceptions;


namespace Platform.Services.Client.Product.Exceptions;

public class CategoryNotFoundException : BaseException
{
    public override string Message => "Category not found";
}
