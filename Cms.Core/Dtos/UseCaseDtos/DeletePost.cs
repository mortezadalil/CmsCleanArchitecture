using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Cms.Core.Dtos.Generals;
using Cms.Core.IUseCases;

namespace Cms.Core.Dtos.UseCaseDtos
{
    public class DeletePostVm
    {
        [Required]
        public int Id { get; set; }

    }
    public class DeletePostRequest : IUseCaseRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }


}
