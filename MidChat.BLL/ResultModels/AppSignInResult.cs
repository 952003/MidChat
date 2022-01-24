using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class AppSignInResult : ResultModel<string>
    {
        public AppSignInResult()
        {
        }

        public AppSignInResult(ResultModel<string> result) : base(result)
        {
        }
    }
}
