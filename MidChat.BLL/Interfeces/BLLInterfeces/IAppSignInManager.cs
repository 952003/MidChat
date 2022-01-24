using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MidChat.BLL.Models;
using MidChat.BLL.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces.BLLInterfeces
{
    public interface IAppSignInManager : IDisposable
    {
        Task<AppRegisterResult> RegistAsync(SignUpModel userSignInModel);

        Task<AppSignInResult> SignInAsync(SignInModel model);

        Task<AppRegisterResult> ExternalRegistAsync();

        Task<AppSignInResult> ExternalSignInAsync();

        Task SignOutAsync();

        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        AuthenticationProperties GetExternalAuthenticationProperties(string provider, string url);
    }

}
