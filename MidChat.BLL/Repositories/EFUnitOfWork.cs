using EntitiesDB.EF;
using MidChat.BLL.Interfeces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext dbContext;

        private IUsersRepository usersRepository;

        private IMessegesRepository messegesRepository;

        private IGroupRepository groupRepository;

        public EFUnitOfWork(MainDbContext dbContext)
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

        public async Task SaveChangeAsync()
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

        ~EFUnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
