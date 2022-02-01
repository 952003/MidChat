using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.EntitiesDTO
{
    public class MessegeModel
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }
    }
}
