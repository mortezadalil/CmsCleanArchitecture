using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Cms.Core.Dtos.Generals;
using Cms.Core.IUseCases;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cms.Api.Presenters
{


    public class PostApiPresenter<T> : IOutputPort<GenericResponse<T>>
    {
        public JsonContentResult ContentResult { get; }

        public PostApiPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GenericResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = ContentResult.Serialize(response.Success ? (object)response.Data : (object)response.Errors);
        }
    }
}
