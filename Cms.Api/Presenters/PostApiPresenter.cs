using System.Net;
using Cms.Core.Dtos.Generals;
using Cms.Core.IUseCases;

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
