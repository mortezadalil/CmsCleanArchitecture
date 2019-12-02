using System;
using System.Collections.Generic;
using System.Globalization;
using Cms.Core.Domain;

namespace Cms.Core.Dtos
{
  public class PostWithoutCommentsAndCategoriesDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Comment> Comments { get; set; }


  }
}
