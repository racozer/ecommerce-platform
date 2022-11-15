using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Platform.Api.Services.Client.Product.Data.Entities;

[Table("Product", Schema = ProductDbContext.Schema)]
public class Product
{
    [Key]
    public long Id { get; set; }
}
