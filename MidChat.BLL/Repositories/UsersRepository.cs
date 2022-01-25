using EntitiesDB.Entities;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.Repositories
{
     public class UsersRepository : DbSetRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
