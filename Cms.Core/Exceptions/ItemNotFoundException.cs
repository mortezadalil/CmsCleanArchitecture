using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Core.Exceptions
{
  public class ItemNotFoundException : Exception
  {
    public override string Message => "Item Not Found";
  }
}
