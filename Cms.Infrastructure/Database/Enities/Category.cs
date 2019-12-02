using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Infrastructure.Database.Enities
{
  public class Category
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<PostCategory> PostCategories { get; set; }

  }

  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Categories");

      builder.HasKey(x => x.Id);

      builder.Property(p => p.Title)
        .HasMaxLength(50);
    }
  }
}
