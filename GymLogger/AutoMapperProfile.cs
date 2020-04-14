using AutoMapper;
using GymLogger.DataAccess.Models;
using GymLogger.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLogger
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();
        }
    }
}
