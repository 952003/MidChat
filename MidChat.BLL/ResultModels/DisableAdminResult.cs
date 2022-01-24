using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class DisableAdminResult : ResultModel<string>
    {
        public int UserId { get; set; }
    }
}
