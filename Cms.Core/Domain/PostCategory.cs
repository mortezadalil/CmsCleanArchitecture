using System;

namespace Cms.Core.Domain
{
  public class PostCategory
  {
    public int Id { get; set; }
    public int PostId { get; set; }
    public int CategoryId { get; set; }

  }
}
