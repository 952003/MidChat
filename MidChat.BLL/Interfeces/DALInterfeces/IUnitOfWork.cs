using EntitiesDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }

        IMessegesRepository MessegesRepository { get; }

        IGroupRepository GroupRepository { get; }

        Task SaveChangeAsync();
    }
}
