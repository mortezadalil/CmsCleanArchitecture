using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos;

namespace Cms.Core.Services
{
  public interface IPostService
  {
    Task<Post> GetById(int id);
    Task<PostWithoutCommentsDto> GetByIdWithoutComments(int id);
    Task<PostWithoutCommentsAndCategoriesDto> GetByIdWithoutCommentsAndCategories(int id);

    Task<PostWithShamsiDateDto> GetByIdAndShamsiDate(int id);
  }
}
