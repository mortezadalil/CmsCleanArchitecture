using System;
using System.Collections.Generic;
using System.Text;
using Cms.Infrastructure.Database.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cms.Infrastructure.Database
{
  public class CmsDbContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public CmsDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new PostConfiguration());
      modelBuilder.ApplyConfiguration(new CommentConfiguration());
      modelBuilder.ApplyConfiguration(new CategoryConfiguration());
      modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
    }
  }

  public class BloggingContextFactory : IDesignTimeDbContextFactory<CmsDbContext>
  {
    public CmsDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<CmsDbContext>();
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-AKTCEF1;Database=CmsDb;Trusted_Connection=True;");


        return new CmsDbContext(optionsBuilder.Options);
    }
  }
}
