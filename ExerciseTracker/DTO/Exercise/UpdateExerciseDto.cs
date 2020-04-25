using ExerciseTracker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracker.DTO.Exercise
{
    public class UpdateExerciseDto
    {
        public int Id { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }

        public DateTime Duration { get; set; }

        public DateTime Time { get; set; }
    }
}
