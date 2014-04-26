using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Serie
    {
        public int id { get; set; }
        public int exerciseunitId { get; set; }
        public int weight { get; set; }
        public int repetition { get; set; }
        public int pause { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }

        public virtual ExerciseUnit exerciseunit { get; set; }
    }
}