using EntitiesDB.EF;
using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
    public class MessegesRepository : DbSetRepository<Messege>, IMessegesRepository
    {
        public MessegesRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
