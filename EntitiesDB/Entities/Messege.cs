using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesDB.Entities
{
     public class Messege
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime SendTime { get; set; }

        public int UserSenderId { get; set; }

        public int GroupId { get; set; }
    }
}
