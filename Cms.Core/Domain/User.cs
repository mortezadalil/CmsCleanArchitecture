using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string RefreshToken { get; set; }
    }
}
