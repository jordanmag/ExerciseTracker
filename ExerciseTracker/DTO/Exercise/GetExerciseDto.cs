using ExerciseTracker.DTO.ExerciseType;
using System;

namespace ExerciseTracker.DTO.Exercise
{
    public class GetExerciseDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public GetExerciseTypeDto ExerciseType { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }

        public DateTime Duration { get; set; }

        public DateTime Time { get; set; }
    }
}
