using System;
using System.Collections.Generic;
using System.Text;
using Cms.Core.Dtos.Generals;
using Cms.Core.Dtos.UseCaseDtos;

namespace Cms.Core.IUseCases
{
  public interface IDeletePostUseCase : IUseCaseRequestHandler<DeletePostRequest, GenericResponse<bool>>
  {

  }
}
