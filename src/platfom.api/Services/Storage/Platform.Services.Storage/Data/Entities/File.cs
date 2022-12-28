using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Platform.Services.Storage.Data.Entities;

[Table("File", Schema = StorageDbContext.Schema)]
public class File
{
    [Key]
    public long Id { get; set; }

    public string? FileName { get; set; }

    public string? Path { get; set; }

    public string? Storage { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
