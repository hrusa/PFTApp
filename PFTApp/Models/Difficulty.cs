using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Difficulty
    {
        public int id { get; set; }
        public string name {get;set;}

        public virtual ICollection<Exercise> exercises { get; set; }
    }
}