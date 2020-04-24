using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExerciseTracker.DataAccess.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }

        public DateTime Duration { get; set; }

        public DateTime Time { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}
