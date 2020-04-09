using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymLogger.DataAccess.Models
{
    public class Exercise
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public ExerciseType ExerciseType { get; set; }

        public int Repititions { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
