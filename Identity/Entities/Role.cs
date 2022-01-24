using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role(string name) : base(name)
        {
        }
    }
}
