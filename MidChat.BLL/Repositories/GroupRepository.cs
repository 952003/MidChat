using EntitiesDB.EF;
using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
    public class GroupRepository : DbSetRepository<Group>, IGroupRepository
    {
        public GroupRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
