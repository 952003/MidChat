using EntitiesDB.EF;
using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
     public class UsersRepository : DbSetRepository<User>, IUsersRepository
    {
        public UsersRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
