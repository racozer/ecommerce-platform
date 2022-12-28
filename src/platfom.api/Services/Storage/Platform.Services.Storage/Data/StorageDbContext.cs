using Microsoft.EntityFrameworkCore;

using File = Platform.Services.Storage.Data.Entities.File;


namespace Platform.Services.Storage.Data;

public class StorageDbContext : DbContext
{
    public const string Schema = "Storage";

    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options) { }

    public DbSet<File> File { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
