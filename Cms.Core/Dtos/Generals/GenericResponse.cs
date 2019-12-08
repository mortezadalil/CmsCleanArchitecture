using System.Collections.Generic;

namespace Cms.Core.Dtos.Generals
{
    public class GenericResponse<T> : UseCaseResponseMessage
    {
        public T Data { get; }
        public IEnumerable<Error> Errors { get; }

        public GenericResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GenericResponse(T data, bool success = true, string message = null) : base(success, message)
        {
            Data = data;
        }
        public GenericResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }

    public abstract class UseCaseResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        protected UseCaseResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
