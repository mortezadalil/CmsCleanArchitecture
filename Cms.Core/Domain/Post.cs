using System;
using System.Collections.Generic;

namespace Cms.Core.Domain
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Category> Categories { get; set; }

  }
}
