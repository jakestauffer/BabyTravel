using AutoMapper;
using BabyTravel.Api.Models.User;
using BabyTravel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.MappingProfiles
{
    public class UserControllerMappingProfile : Profile
    {
        public UserControllerMappingProfile() 
        { 
            CreateMap<User, UserResponse>();
            CreateMap<UserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}
