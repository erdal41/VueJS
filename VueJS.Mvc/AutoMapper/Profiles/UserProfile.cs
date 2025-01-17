﻿using AutoMapper;
using VueJS.Entities.Concrete;
using VueJS.Entities.Dtos;
using VueJS.Mvc.Areas.Admin.Models.View;

namespace VueJS.Mvc.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserAddDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserViewModel, User>();

            CreateMap<UserLoginViewModel, User>();
            CreateMap<User, UserLoginViewModel>();
        }
    }
}
