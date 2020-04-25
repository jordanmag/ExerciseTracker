using ExerciseTracker.DataAccess.Models;
using System;

namespace ExerciseTracker.DTO.Exercise
{
    public class AddExerciseDto
    {
        public int ExerciseTypeId { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }

        public DateTime Duration { get; set; }

        public DateTime Time { get; set; }
    }
}
