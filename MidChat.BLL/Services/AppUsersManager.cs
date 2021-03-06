using AutoMapper;
using Identity.Interfaces;
using MidChat.BLL.Interfeces.BLLInterfeces;
using MidChat.BLL.Interfeces.BLLInterfeces.CRUDService;
using MidChat.BLL.Models;
using MidChat.BLL.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Services
{
    public class AppUsersManager : IAppUsersManager
    {
        private readonly IIdentityUnitOfWork identityUnitOfWork;

        private readonly IUserCrudService userCrudService;

        private readonly IMapper mapper;

        public AppUsersManager(IIdentityUnitOfWork identityUnitOfWork, IMapper mapper, IUserCrudService userCrudService)
        {
            this.identityUnitOfWork = identityUnitOfWork;
            this.mapper = mapper;
            this.userCrudService = userCrudService;
        }

        public async Task<AppUserModel> GetUserAsync(int id)
        {
            var user = await userCrudService.GetAsync(id);
            var idenUser = await identityUnitOfWork.UserManager.FindByIdAsync(id.ToString());
            var appUser = mapper.Map<AppUserModel>(user);
            appUser.Roles = await identityUnitOfWork.UserManager.GetRolesAsync(idenUser);
            return appUser;
        }

        public async Task<IEnumerable<AppUserModel>> GetAllUsersAsync()
        {
            var appUsers = new List<AppUserModel>();
            var users = await userCrudService.GetAllAsync();
            foreach(var user in users)
            {
                var idenUser = await identityUnitOfWork.UserManager.FindByIdAsync(user.Id.ToString());
                if (idenUser is null)
                    continue;
                var appUser = mapper.Map<AppUserModel>(user);
                appUser.Roles = await identityUnitOfWork.UserManager.GetRolesAsync(idenUser);
                appUsers.Add(appUser);
            }
            return appUsers;
        }

        public async Task<DeleteUsersResult> DeleteUsersAsync(IEnumerable<int> userIds)
        {
            var result = new DeleteUsersResult();
            foreach (var id in userIds)
            {
                var appUser = await identityUnitOfWork.UserManager.FindByIdAsync(id.ToString());
                if(appUser is null)
                {
                    result.AddError($"User {id} not found");
                    result.NotDeletedUsers.Add(id);
                }
                else
                {
                    await userCrudService.DeleteAsync(id);
                    await identityUnitOfWork.UserManager.DeleteAsync(appUser);
                    result.DeletedUsers.Add(id);
                }
            }
            return result;
        }

        public async Task<BlockUsersResult> BlockUsersAsync(IEnumerable<int> userIds)
        {
            var result = new BlockUsersResult();
            foreach (var id in userIds)
            {
                var appUser = await identityUnitOfWork.UserManager.FindByIdAsync(id.ToString());
                if(appUser is null || appUser.Email == "admin@mail.com")
                {
                    result.AddError($"User {id} not found");
                    result.NotBlocked.Add(id);
                    continue;
                }
                var idenRes = await identityUnitOfWork.UserManager.AddToRoleAsync(appUser, "blocked");
                if (!idenRes.Succeeded)
                {
                    result.AddError("Identity error");
                    result.NotBlocked.Add(id);
                    continue;
                }
                result.Blocked.Add(id);
            }
            return result;
        }

        public async Task<UnblockUsersResult> UnblockUsersAsync(IEnumerable<int> userIds)
        {
            var result = new UnblockUsersResult();
            foreach(var id in userIds)
            {
                var appUser = await identityUnitOfWork.UserManager.FindByIdAsync(id.ToString());
                if(appUser is null)
                {
                    result.AddError($"User {id} not found");
                    result.NotUnblocked.Add(id);
                    continue;
                }
                var idenRes = await identityUnitOfWork.UserManager.RemoveFromRoleAsync(appUser, "blocked");
                if (!idenRes.Succeeded)
                {
                    result.AddError("Identity error");
                    result.NotUnblocked.Add(id);
                    continue;
                }
                result.Unblocked.Add(id);
            }
            return result;
        }

        public async Task<EnableAdminResult> EnableAdminRules(int userId)
        {
            var result = new EnableAdminResult();
            var appUser = await identityUnitOfWork.UserManager.FindByIdAsync(userId.ToString());
            if(appUser is null)
            {
                result.AddError("User not found");
                return result;
            }
            var idenRes = await identityUnitOfWork.UserManager.AddToRoleAsync(appUser, "admin");
            if (!idenRes.Succeeded)
            {
                result.AddError("Identity error");
                return result;
            }
            result.UserId = userId;
            return result;
        }

        public async Task<DisableAdminResult> DisableAdminRules(int userId)
        {
            var result = new DisableAdminResult();
            var appUser = await identityUnitOfWork.UserManager.FindByIdAsync(userId.ToString());
            if(appUser is null)
            {
                result.AddError("user not found");
                return result;
            }
            var idenRes = await identityUnitOfWork.UserManager.RemoveFromRoleAsync(appUser, "admin");
            if (!idenRes.Succeeded)
            {
                result.AddError("Identity error");
                return result;
            }
            result.UserId = userId;
            return result;
        }

        #region Disposable

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    identityUnitOfWork.Dispose();
                }
                disposed = true;
            }
        }

        ~AppUsersManager()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}
