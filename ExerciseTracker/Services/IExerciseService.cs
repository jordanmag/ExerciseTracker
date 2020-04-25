using ExerciseTracker.DTO.Exercise;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    public interface IExerciseService
    {
        Task<ServiceResponse<List<GetExerciseDto>>> GetAllExercises();

        Task<ServiceResponse<GetExerciseDto>> GetExerciseById(int id);

        Task<ServiceResponse<List<GetExerciseDto>>> AddExercise(AddExerciseDto newExercise);

        Task<ServiceResponse<GetExerciseDto>> UpdateExercise(UpdateExerciseDto updatedExercise);

        Task<ServiceResponse<List<GetExerciseDto>>> DeleteExercise(int id);
    }
}
