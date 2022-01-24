using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class EnableAdminResult : ResultModel<string>
    {
        public int UserId { get; set; }
    }
}
