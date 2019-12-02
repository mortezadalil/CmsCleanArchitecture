using System;

namespace Cms.Core.Domain
{
  public class Comment
  {
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }

  }
}
