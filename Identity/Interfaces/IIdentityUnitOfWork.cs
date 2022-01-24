using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        UserManager<AppUser> UserManager { get; }

        SignInManager<AppUser> SignInManager { get; }
    }
}
