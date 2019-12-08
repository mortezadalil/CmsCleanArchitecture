using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Cms.Core.Dtos.Generals;
using Cms.Core.IUseCases;

namespace Cms.Core.Dtos.UseCaseDtos
{
    public class AddPostVm
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
    public class AddPostRequest : IUseCaseRequest<GenericResponse<AddPostResponse>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }

    }

    public class AddPostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
