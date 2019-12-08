using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Cms.Core.Dtos;

namespace Cms.Core.Queries
{
  public class GetAllPostQuery:IRequest<List<PostWithoutCommentsDto>>
  {

  }
}
