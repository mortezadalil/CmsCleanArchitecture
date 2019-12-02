using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Infrastructure.Database.Enities
{
  public class PostCategory
  {
    public int Id { get; set; }


    public int PostId { get; set; }
    public Post Post { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }

  }
  public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
  {
    public void Configure(EntityTypeBuilder<PostCategory> builder)
    {
      builder.ToTable("PostCategoriess");

      builder.HasKey(x => x.Id);

      builder.HasIndex(bc => new { bc.PostId, bc.CategoryId });

      builder.HasOne(bc => bc.Post)
          .WithMany(b => b.PostCategories)
          .HasForeignKey(bc => bc.PostId);

      builder.HasOne(bc => bc.Category)
          .WithMany(c => c.PostCategories)
          .HasForeignKey(bc => bc.CategoryId);


    }
  }
}
