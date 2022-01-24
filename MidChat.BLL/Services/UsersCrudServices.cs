using AutoMapper;
using EntitiesDB.Entities;
using Microsoft.EntityFrameworkCore;
using MidChat.BLL.EntitiesDTO;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Interfeces.BLLInterfeces.CRUDService;
using MidChat.BLL.Services.CRUDServ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Services
{
    public class UsersCrudServices : CRUDServices<User, UserModel>, IUserCrudService
    {
        protected override IRepository<User> BaseRepository
        {
            get
            {
                return unitOfWork.UsersRepository;
            }
        }

        public UsersCrudServices(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<UserModel> GetAsync(string username)
        {
            var user = await BaseRepository.GetAll().FirstOrDefaultAsync(u => u.Username == username);
            var model = mapper.Map<UserModel>(user);
            return model;
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await BaseRepository.Get(id);
            // entity.SomeShit.ToList().ForEach(c => uofw.SomeShitRepository.Delete(c.Id));
            await BaseRepository.Delete(id);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
