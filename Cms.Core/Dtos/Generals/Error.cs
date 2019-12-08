using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Core.Dtos.Generals
{
    public sealed class Error
    {
        public string Code { get; }
        public string Description { get; }
        public string Stack { get; }

        public Error(string code, string description, string stack = "")
        {
            Code = code;
            Description = description;
            Stack = stack;
        }
    }
}
