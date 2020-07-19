using ExerciseTracker.DTO.Exercise;
using ExerciseTracker.DTO.ExerciseType;
using ExerciseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExerciseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IExerciseTypeService _exerciseTypeService;

        public ExerciseTypeController(IExerciseTypeService exerciseService)
        {
            _exerciseTypeService = exerciseService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _exerciseTypeService.GetAllExerciseTypes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _exerciseTypeService.GetExerciseTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Addexercise(AddExerciseTypeDto newExerciseType)
        {
            return Ok(await _exerciseTypeService.AddExerciseType(newExerciseType));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExercise(UpdateExerciseTypeDto updatedExerciseType)
        {
            var response = await _exerciseTypeService.UpdateExerciseType(updatedExerciseType);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _exerciseTypeService.DeleteExerciseType(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
