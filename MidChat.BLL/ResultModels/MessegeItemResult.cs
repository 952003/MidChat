using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class MessegeItemResult : ResultModel<string>
    {
        public string UserName { get; set; }

        public string Value { get; set; }

        public string Date { get; set; }

        public MessegeItemResult()
        {
        }

        public MessegeItemResult(ResultModel<string> result) : base(result)
        {
        }
    }
}
