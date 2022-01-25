using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
    public class MessegesRepository : DbSetRepository<Messege>, IMessegesRepository
    {
        public MessegesRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
