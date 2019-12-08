using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Dtos.Generals;
using Cms.Core.Dtos.UseCaseDtos;
using Cms.Core.Exceptions;
using Cms.Core.IRepositories;
using Cms.Core.IUseCases;

namespace Cms.Core.UseCases
{
    public class DeletePostUseCase : IDeletePostUseCase
    {
        private readonly IPostRepository _postRepository;

        public DeletePostUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task HandleAsync(DeletePostRequest message, IOutputPort<GenericResponse<bool>> outputPort)
        {
            try
            {
                var isExist = await _postRepository.IsPostExist(message.Id);

                if (!isExist)
                {
                    throw new ItemNotFoundException();
                }

                await _postRepository.RemoveById(message.Id);

                outputPort.Handle(new GenericResponse<bool>(true,""));

            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException)
                {
                    outputPort.Handle(new GenericResponse<bool>(new[] {
                        new Error(ex.HResult.ToString(), ex.Message)
                    }));
                }
                else
                {
                    outputPort.Handle(new GenericResponse<bool>(new[] {
                        new Error("0", "خطا در دریافت اطلاعات",ex.ToString())
                    }));
                }
            }
        }
    }

}
