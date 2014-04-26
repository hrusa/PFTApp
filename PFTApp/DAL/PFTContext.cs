using PFTApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PFTApp.DAL
{
    public class PFTContext : DbContext
    {
        public PFTContext()
            : base("PFTContext")
        {

        }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseUnit> ExerciseUnits { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        //Using singular table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}