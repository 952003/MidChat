using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using MidChat.BLL.Models;

namespace MidChat.BLL.MappingProfile
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<ExternalLoginInfo, AppUser>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Principal.FindFirstValue(ClaimTypes.Email)))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Principal.FindFirstValue(ClaimTypes.Email)));
            CreateMap<SignInModel, AppUser>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
        }
    }
}
