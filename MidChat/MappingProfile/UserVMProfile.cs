using AutoMapper;
using MidChat.ViewModels;
using MidChat.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidChat.MappingProfile
{
    public class UserVMProfile : Profile
    {
        public UserVMProfile()
        {
            CreateMap<UserModel, UserVM>().ReverseMap();
        }
    }
}
