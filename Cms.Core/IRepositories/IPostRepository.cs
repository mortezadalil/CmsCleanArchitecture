using System.Collections.Generic;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos.UseCaseDtos;

namespace Cms.Core.IRepositories
{
  public interface IPostRepository
  {
    Task<Post> GetById(int id);
    Task<Post> GetByIdWithoutIncludes(int id);

    Task<Post> Add(Post post);
    Task<bool> IsPostExist(int id);
    Task RemoveById(int id);
    Task<List<Post>> GetAll();
  }
}
