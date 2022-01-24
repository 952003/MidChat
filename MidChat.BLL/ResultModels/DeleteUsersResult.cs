using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.ResultModels
{
    public class DeleteUsersResult : ResultModel<string>
    {
        public IList<int> DeletedUsers { get; } = new List<int>();

        public IList<int> NotDeletedUsers { get; } = new List<int>();
    }
}
