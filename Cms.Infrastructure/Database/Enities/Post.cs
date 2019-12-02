using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Infrastructure.Database.Enities
{
  public class Post
  {

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<PostCategory> PostCategories { get; set; }



  }
  public class PostConfiguration : IEntityTypeConfiguration<Post>
  {
    public void Configure(EntityTypeBuilder<Post> builder)
    {
      builder.ToTable("Posts");

      builder.HasKey(x=>x.Id);


      builder.Property(p => p.Title)
        .HasMaxLength(50);

      builder.Property(p => p.Content)
        .HasMaxLength(1000);

     
    }
  }
}
