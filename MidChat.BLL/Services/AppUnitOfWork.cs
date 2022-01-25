using MidChat.BLL.Interfeces;
using MidChat.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Services
{
    public class AppUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        private IUsersRepository usersRepository;

        private IMessegesRepository messegesRepository;

        private IGroupRepository groupRepository;

        public AppUnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                return usersRepository ?? (usersRepository = new UsersRepository(dbContext));
            }
        }

        public IMessegesRepository MessegesRepository
        {
            get
            {
                return messegesRepository ?? (messegesRepository = new MessegesRepository(dbContext));
            }
        }

        public IGroupRepository GroupRepository
        {
            get
            {
                return groupRepository ?? (groupRepository = new GroupRepository(dbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        #region Disposable

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        ~AppUnitOfWork()
        {
            Dispose(false);
        }

        #endregion Disposable
    }
}
