using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesDB.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string UserSendName { get; set; }

        public DateTime LastMessTime { get; set; }
    }
}
