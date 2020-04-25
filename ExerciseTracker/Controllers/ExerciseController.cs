using ExerciseTracker.DTO.Exercise;
using ExerciseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExerciseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _exerciseService.GetAllExercises());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _exerciseService.GetExerciseById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Addexercise(AddExerciseDto newexercise)
        {
            return Ok(await _exerciseService.AddExercise(newexercise));
        }

        [HttpPut]
        public async Task<IActionResult> Updateexercise(UpdateExerciseDto updatedexercise)
        {
            var response = await _exerciseService.UpdateExercise(updatedexercise);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _exerciseService.DeleteExercise(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
