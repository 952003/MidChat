using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class UnblockUsersResult : ResultModel<string>
    {
        public IList<int> Unblocked { get; } = new List<int>();

        public IList<int> NotUnblocked { get; } = new List<int>();
    }
}
