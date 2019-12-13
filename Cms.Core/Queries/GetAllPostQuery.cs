using MediatR;
using System.Collections.Generic;
using Cms.Core.Dtos;

namespace Cms.Core.Queries
{
  public class GetAllPostQuery:IRequest<List<PostWithoutCommentsDto>>
  {

  }
}
