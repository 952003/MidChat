using AutoMapper;
using MidChat.BLL.EntitiesDTO;
using MidChat.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidChat.BLL.MappingProfile
{
    public class AppUserModelProfile : Profile
    {
        public AppUserModelProfile()
        {
            CreateMap<UserModel, AppUserModel>();
        }
    }
}
