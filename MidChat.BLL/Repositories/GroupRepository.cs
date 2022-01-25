using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
    public class GroupRepository : DbSetRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
