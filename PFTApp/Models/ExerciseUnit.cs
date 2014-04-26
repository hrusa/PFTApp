using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class ExerciseUnit
    {
        public int id { get; set; }
        public int exerciseId { get; set; }
        public int workoutId { get; set; }
        public Boolean done { get; set; }

        public virtual Exercise exercise { get; set; }
        public virtual Workout workout { get; set; }
        public virtual ICollection<Serie> series { get; set; }
    }
}