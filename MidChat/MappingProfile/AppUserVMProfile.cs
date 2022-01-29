using AutoMapper;
using MidChat.BLL.Models;
using MidChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidChat.MappingProfile
{
    public class AppUserVMProfile : Profile
    {
        public AppUserVMProfile()
        {
            CreateMap<AppUserModel, AppUserVm>()
                .ForMember(o => o.IsAdmin, p => p.MapFrom(s => s.Roles.Contains("admin")))
                .ForMember(o => o.IsBlocked, p => p.MapFrom(s => s.Roles.Contains("blocked")));
        }
    }
}
