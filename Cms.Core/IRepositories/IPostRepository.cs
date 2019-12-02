using System.Threading.Tasks;
using Cms.Core.Domain;

namespace Cms.Core.IRepositories
{
  public interface IPostRepository
  {
    Task<Post> GetById(int id);
    Task<Post> GetByIdWithoutIncludes(int id);

  }
}
