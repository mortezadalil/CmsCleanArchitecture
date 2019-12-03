using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Dtos.UseCaseDtos;
using Cms.Core.IUseCases;

namespace Cms.Core.UseCases
{
  class AddPostUseCase : IAddPostUseCase
  {
    public AddPostUseCase()
    {
      
    }
    public Task HandleAsync(AddPostRequest message, IOutputPort<AddPostResponse> outputPort)
    {
      
    }
  }
 
}
