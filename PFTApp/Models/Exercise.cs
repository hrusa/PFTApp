using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Exercise
    {
        public int id { get; set; }
        public string name { get; set; }
        public int difficultyId{ get; set; }
        public string description { get; set; }
        public string video { get; set; }
        public int musclegroupId { get; set; }

        public virtual Difficulty difficulty { get; set; }
        public virtual MuscleGroup musclegroup { get; set; }
        public virtual ICollection<ExerciseUnit> exerciseunits { get; set; }
    }
}