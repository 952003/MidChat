using MidChat.BLL.EntitiesDTO;
using MidChat.BLL.Models;
using MidChat.BLL.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces.BLLInterfeces
{
    public interface IAppUsersManager : IDisposable 
    {
        Task<AppUserModel> GetUserAsync(int id);

        Task<IEnumerable<AppUserModel>> GetAllUsersAsync();

        Task<DeleteUsersResult> DeleteUsersAsync(IEnumerable<int> userIds);

        Task<BlockUsersResult> BlockUsersAsync(IEnumerable<int> Ids);

        Task<UnblockUsersResult> UnblockUsersAsync(IEnumerable<int> Ids);

        Task<EnableAdminResult> EnableAdminRules(int userId);

        Task<DisableAdminResult> DisableAdminRules(int userId);
    }
}
