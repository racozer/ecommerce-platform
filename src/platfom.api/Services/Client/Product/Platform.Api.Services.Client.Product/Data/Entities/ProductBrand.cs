using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Platform.Api.Services.Client.Product.Data.Entities;

[Table("ProductBrand", Schema = ProductDbContext.Schema)]
public class ProductBrand
{
    [Key]
    public long Id { get; set; }

    public long ImageId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }
}
