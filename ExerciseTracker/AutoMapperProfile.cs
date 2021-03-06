﻿using AutoMapper;
using ExerciseTracker.DataAccess.Models;
using ExerciseTracker.DTO.Exercise;
using ExerciseTracker.DTO.ExerciseType;
using ExerciseTracker.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();

            CreateMap<Exercise, GetExerciseDto>();
            CreateMap<AddExerciseDto, Exercise>();

            CreateMap<ExerciseType, GetExerciseTypeDto>();
            CreateMap<AddExerciseTypeDto, ExerciseType>();
        }
    }
}
