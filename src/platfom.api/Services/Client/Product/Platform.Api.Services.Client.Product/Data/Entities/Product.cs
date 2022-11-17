using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Platform.Api.Services.Client.Product.Data.Enums;


namespace Platform.Api.Services.Client.Product.Data.Entities;

[Table("Product", Schema = ProductDbContext.Schema)]
public class Product
{
    [Key]
    public long Id { get; set; }

    public long BrandId { get; set; }

    public long VendorId { get; set; }
    
    public long CategoryId { get; set; }

    public long ImageId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ShortDescription { get; set; }

    public float Weight { get; set; }

    public float MaxQuantityPerCart { get; set; }

    public ProductType ProductType { get; set; }

    public DateTime CreatedDate { get; set; }
    
    public DateTime LastUpdatedDate { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }
}
