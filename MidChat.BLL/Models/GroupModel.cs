using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.EntitiesDTO
{
    public class GroupModel
    {
        public int Id { get; set; }

        public string UserSendName { get; set; }

        public DateTime LastMessTime { get; set; }
    }
}
