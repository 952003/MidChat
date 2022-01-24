using AutoMapper;
using EntitiesDB.Entities;
using MidChat.BLL.EntitiesDTO;

namespace MidChat.BLL.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
