﻿using AutoMapper;
using ComplantSystem.Data;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models;

namespace ComplantSystem
{
    public class UploadProfile : Profile
    {
        public UploadProfile()
        {

            CreateMap<InputCompmallintVM, UploadsComplainte>()
    .ForMember(u => u.Id, op => op.Ignore())
    .ForMember(u => u.UploadDate, op => op.Ignore());



            CreateMap<UploadsComplainte, InputCompmallintVM>();
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<ApplicationUser, AdminUserViewModel>()
                .ForMember(u => u.Password, op => op.MapFrom(u => u.PasswordHash != null));


            CreateMap<ApplicationUser, UserProfileEditVM>();
            CreateMap<ApplicationUser, UsersViewModel>();

        }

    }
}