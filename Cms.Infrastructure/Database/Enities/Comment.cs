using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Infrastructure.Database.Enities
{
  public class Comment
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }


    public int PostId { get; set; }
    public Post Post { get; set; }


  }

  public class CommentConfiguration : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.ToTable("Comments");

      builder.HasKey(x => x.Id);

      builder.Property(p => p.Name)
        .HasMaxLength(50);

      builder.Property(p => p.Email)
        .HasMaxLength(50);

      builder.Property(p => p.Content)
        .HasMaxLength(500);

      builder
        .HasOne(e => e.Post)
        .WithMany(c => c.Comments);


    }
  }
}
