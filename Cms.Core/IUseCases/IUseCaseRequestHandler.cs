using System.Threading.Tasks;

namespace Cms.Core.IUseCases
{
  public interface IUseCaseRequest<out TUseCaseResponse> { }

  public interface IOutputPort<in TUseCaseResponse>
  {
    void Handle(TUseCaseResponse response);
  }

  public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
  {
    Task HandleAsync(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
  }


}
