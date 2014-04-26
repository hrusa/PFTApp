using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Workout
    {
        public int id { get; set; }
        public int trainingId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public Boolean done { get; set; }

        public virtual Training training { get; set; }
        public virtual ICollection<ExerciseUnit> exerciseunits { get; set; }
    }
}