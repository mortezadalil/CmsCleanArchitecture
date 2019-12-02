using System;
using System.Threading.Tasks;
using Cms.Core.Exceptions;
using Cms.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : BaseController
  {
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
      _postService = postService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var result = await _postService.GetById(id);
        
        return CustomeOk(result);

      }
      catch (Exception e)
      {
        if (e is ItemNotFoundException)
        {
          return CustomeError(e.Message);
        }
        return CustomeError(e.ToString());
      }

    }

    [HttpGet("get_with_additional_data/{id}")]
    public async Task<IActionResult> GetWithAdditionalData(int id)
    {
      var result = await _postService.GetByIdAndShamsiDate(id);

      return Ok(result);
    }
  }
}
