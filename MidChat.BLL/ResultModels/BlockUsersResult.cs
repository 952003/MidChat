using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class BlockUsersResult : ResultModel<string>
    {
        public IList<int> Blocked { get; } = new List<int>();

        public IList<int> NotBlocked { get; } = new List<int>();
    }
}
