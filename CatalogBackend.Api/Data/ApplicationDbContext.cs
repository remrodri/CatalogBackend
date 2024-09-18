using CatalogBackend.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogBackend.Api.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configure the Category entity
      modelBuilder.Entity<Category>(entity =>
      {
         entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.HasOne(e => e.ParentCategory)
          .WithMany(e => e.SubCategories)
          .HasForeignKey(e => e.ParentCategoryId);
      });
        
    }
  }
}
