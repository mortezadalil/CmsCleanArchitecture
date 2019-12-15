using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Cms.Core.Dtos.Generals;
using Cms.Core.IUseCases;
using MediatR;

namespace Cms.Core.Dtos.UseCaseDtos
{

    public class AddPostCommand : IRequest<AddPostResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }

    }


}
