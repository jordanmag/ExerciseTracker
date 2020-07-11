using ExerciseTracker.DTO.ExerciseType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public interface IExerciseTypeService
    {
        Task<ServiceResponse<List<GetExerciseTypeDto>>> GetAllExerciseTypes();

        Task<ServiceResponse<GetExerciseTypeDto>> GetExerciseTypeById(int id);

        Task<ServiceResponse<List<GetExerciseTypeDto>>> AddExerciseType(AddExerciseTypeDto newExercise);

        Task<ServiceResponse<GetExerciseTypeDto>> UpdateExerciseType(UpdateExerciseTypeDto updatedExercise);

        Task<ServiceResponse<List<GetExerciseTypeDto>>> DeleteExerciseType(int id);
    }
}
