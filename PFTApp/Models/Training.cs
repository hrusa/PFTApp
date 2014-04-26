using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Training
    {
        public int id { get; set; }
        public int traineeId { get; set; }
        public string name { get; set; }

        public virtual Trainee trainee { get; set; }
    }
}