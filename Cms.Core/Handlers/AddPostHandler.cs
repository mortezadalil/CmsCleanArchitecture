using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos;
using Cms.Core.Dtos.UseCaseDtos;
using Cms.Core.IRepositories;
using Cms.Core.Queries;
using MediatR;

namespace Cms.Core.Handlers
{
  public class AddPostHandler : IRequestHandler<AddPostCommand, AddPostResponse>
  {
    private readonly IPostRepository _postRepository;

    public AddPostHandler(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }
    public async Task<AddPostResponse> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
      var addedItem = await _postRepository.Add(new Post
      {
        Content = request.Content,
        Title = request.Title
      });
      return new AddPostResponse
      {
        Content = addedItem.Content,
        ModifiedDate = addedItem.ModifiedDate,
        Title = addedItem.Title,
        CreatedDate = addedItem.CreatedDate,
        Id = addedItem.Id
      };



    }
  }
}
