using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos;
using Cms.Core.IRepositories;
using Cms.Core.Queries;
using MediatR;

namespace Cms.Core.Handlers
{
  public class GetAllPostHandler : IRequestHandler<GetAllPostQuery, List<PostWithoutCommentsDto>>
  {
    private readonly IPostRepository _postRepository;

    public GetAllPostHandler(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }
    public async Task<List<PostWithoutCommentsDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
      var posts = await _postRepository.GetAll();

      return posts.Select(x => new PostWithoutCommentsDto
      {
        Content = x.Content,
        ModifiedDate = x.ModifiedDate,
        CreatedDate = x.CreatedDate,
        Title = x.Title,
        Id = x.Id
      }).ToList();

    }
  }
}
