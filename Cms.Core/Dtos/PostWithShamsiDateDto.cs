using System;
using System.Collections.Generic;
using System.Globalization;
using Cms.Core.Domain;

namespace Cms.Core.Dtos
{
  public class PostWithShamsiDateDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public string ModifiedDateShamsi
    {
      get
      {
        var pc = new PersianCalendar();
        return $"{pc.GetYear(CreatedDate)}/{pc.GetMonth(CreatedDate)}/{pc.GetDayOfMonth(CreatedDate)}";
      }
    }

    public long Miliseconds { get; set; }

  }
}
