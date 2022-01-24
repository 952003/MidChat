using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class AppRegisterResult : ResultModel<string>
    {
        public AppRegisterResult()
        {
        }

        public AppRegisterResult(ResultModel<string> result) : base(result)
        {
        }

        public AppRegisterResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                Errors.Add(error.Description);
            }
        }
    }
}
