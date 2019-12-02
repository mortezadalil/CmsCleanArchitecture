using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos;
using Cms.Core.Exceptions;
using Cms.Core.IRepositories;

namespace Cms.Core.Services
{
  public class PostService : IPostService
  {
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }
    public async Task<Post> GetById(int id)
    {
      var item = await _postRepository.GetById(id);
      
      if (item == null)
        throw new ItemNotFoundException();

      return item;
    }

    public async Task<PostWithoutCommentsDto> GetByIdWithoutComments(int id)
    {
      var dbItemWithIncludes = await _postRepository.GetById(id);

      //Use AutoMapper Package for simplicity.
      return new PostWithoutCommentsDto
      {
        Id = dbItemWithIncludes.Id,
        Content = dbItemWithIncludes.Content,
        CreatedDate = dbItemWithIncludes.CreatedDate,
        Title = dbItemWithIncludes.Title,
        ModifiedDate = dbItemWithIncludes.ModifiedDate,
        Categories = dbItemWithIncludes.Categories
      };

    }

    public async Task<PostWithoutCommentsAndCategoriesDto> GetByIdWithoutCommentsAndCategories(int id)
    {
      var dbItemWithoutIncludes = await _postRepository.GetByIdWithoutIncludes(id);

      //Use AutoMapper Package for simplicity.
      return new PostWithoutCommentsAndCategoriesDto
      {
        Id = dbItemWithoutIncludes.Id,
        Content = dbItemWithoutIncludes.Content,
        CreatedDate = dbItemWithoutIncludes.CreatedDate,
        Title = dbItemWithoutIncludes.Title,
        ModifiedDate = dbItemWithoutIncludes.ModifiedDate
      };
    }

    public async Task<PostWithShamsiDateDto> GetByIdAndShamsiDate(int id)
    {
      var timer = new Stopwatch();
      timer.Start();
      var dbItemWithoutIncludes = await _postRepository.GetByIdWithoutIncludes(id);
      timer.Stop();


      //Use AutoMapper Package for simplicity.
      return new PostWithShamsiDateDto
      {
        Id = dbItemWithoutIncludes.Id,
        Content = dbItemWithoutIncludes.Content,
        CreatedDate = dbItemWithoutIncludes.CreatedDate,
        Title = dbItemWithoutIncludes.Title,
        ModifiedDate = dbItemWithoutIncludes.ModifiedDate,
        Miliseconds = timer.ElapsedMilliseconds
      };
    }
  }
}
