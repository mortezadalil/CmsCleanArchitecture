using System;
using System.Threading.Tasks;
using Cms.Api.Presenters;
using Cms.Core.Dtos.UseCaseDtos;
using Cms.Core.Exceptions;
using Cms.Core.IUseCases;
using Cms.Core.Queries;
using Cms.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : BaseController
  {
    private readonly IMediator _mediator;
    private readonly IPostService _postService;
    private readonly IAddPostUseCase _addPostUseCase;
    private readonly IDeletePostUseCase _deletePostUseCase;
    private readonly PostApiPresenter<bool> _deleteApiPresenter;
    private readonly PostApiPresenter<AddPostResponse> _addApiPresenter;

    public PostController(
        IMediator mediator,
        IPostService postService,
        IAddPostUseCase addPostUseCase,
        IDeletePostUseCase deletePostUseCase,
        PostApiPresenter<bool> deleteApiPresenter,
        PostApiPresenter<AddPostResponse> addApiPresenter
        )
    {
      _mediator = mediator;
      _postService = postService;
      _addPostUseCase = addPostUseCase;
      _deletePostUseCase = deletePostUseCase;
      _deleteApiPresenter = deleteApiPresenter;
      _addApiPresenter = addApiPresenter;
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


    [HttpPost]
    public async Task<IActionResult> Add(AddPostVm model)
    {
      await _addPostUseCase.HandleAsync(new AddPostRequest
      {
        Content = model.Content,
        Title = model.Title
      }, _addApiPresenter);

      return _addApiPresenter.ContentResult;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _deletePostUseCase.HandleAsync(new DeletePostRequest
      {
        Id = id
      }, _deleteApiPresenter);

      return _deleteApiPresenter.ContentResult;
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      var query = new GetAllPostQuery();
      var result = await _mediator.Send(query);
      return Ok(result);

    }


    [HttpPost("Add2")]
    public async Task<IActionResult> Add2([FromBody]AddPostCommand command)
    {
      var result = await _mediator.Send(command);
      return Ok(result);
    }
  }
}
