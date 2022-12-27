using Platform.Core.Exceptions;


namespace Platform.Services.Client.Product.Exceptions;

public class ProductBrandNotFoundException : BaseException
{
    public override string Message => "Product Brand not found";
}
