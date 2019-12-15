using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
  public class BaseController : ControllerBase
  {
    public ActionResult CustomeOk(object data, string message = "")
    {
      return Ok(new Result()
      {
        Message = message,
        Data = data,
        Status = Status.Success
      });
    }
    public ActionResult CustomeError(string message = "", object data = null)
    {
      return BadRequest(new Result()
      {
        Message = message,
        Data = data,
        Status = Status.Failed
      });
    }



    

    }

    public class Result
  {
    public object Data { get; set; }
    public Status Status { get; set; }
    public string Message { get; set; }
  }
  public enum Status
  {
    Success = 1,
    Failed = -1
  }
}
