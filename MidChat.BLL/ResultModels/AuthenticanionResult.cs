using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class AuthenticanionResult : ResultModel<string>
    {
        public AuthenticanionResult() : base()
        {
        }

        public AuthenticanionResult(ResultModel<string> result) : base(result)
        {
        }
    }
}
