using AutoMapper;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using MidChat.BLL.EntitiesDTO;
using MidChat.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MidChat.BLL.MappingProfile
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<ExternalLoginInfo, UserModel>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Principal.FindFirstValue(ClaimTypes.GivenName)))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.Principal.FindFirstValue(ClaimTypes.Surname)))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Principal.FindFirstValue(ClaimTypes.Email)));
            CreateMap<AppUser, UserModel>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Email));
            CreateMap<SignInModel, UserModel>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Email));
        }
    }
}
