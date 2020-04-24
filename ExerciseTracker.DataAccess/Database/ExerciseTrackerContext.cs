using ExerciseTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseTracker.DataAccess.Database
{
    public class ExerciseTrackerContext : DbContext
    {
        public ExerciseTrackerContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
    }
}
