using ExerciseTracker.DTO.ExerciseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        public Task<ServiceResponse<List<GetExerciseTypeDto>>> AddExerciseType(AddExerciseTypeDto newExercise)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetExerciseTypeDto>>> DeleteExerciseType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetExerciseTypeDto>>> GetAllExerciseTypes()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetExerciseTypeDto>> GetExerciseTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetExerciseTypeDto>> UpdateExerciseType(UpdateExerciseTypeDto updatedExercise)
        {
            throw new NotImplementedException();
        }
    }
}
