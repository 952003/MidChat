using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidChat.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Icon { get; set; }

        public string Role { get; set; }
    }
}
