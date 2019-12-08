using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Dtos.Generals;
using Cms.Core.Dtos.UseCaseDtos;
using Cms.Core.IRepositories;
using Cms.Core.IUseCases;

namespace Cms.Core.UseCases
{
    public class AddPostUseCase : IAddPostUseCase
    {
        private readonly IPostRepository _postRepository;

        public AddPostUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task HandleAsync(AddPostRequest message, IOutputPort<GenericResponse<AddPostResponse>> outputPort)
        {
            var addedItem = await _postRepository.Add(new Post
            {
                Content = message.Content,
                Title = message.Title,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            var outputObject = new GenericResponse<AddPostResponse>(new AddPostResponse
            {
                Content = addedItem.Content,
                ModifiedDate = addedItem.ModifiedDate,
                Title = addedItem.Title,
                CreatedDate = addedItem.CreatedDate,
                Id = addedItem.Id
            });

            outputPort.Handle(outputObject);
        }
    }

}
