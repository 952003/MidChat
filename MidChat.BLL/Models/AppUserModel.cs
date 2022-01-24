using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Models
{
    public class AppUserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
