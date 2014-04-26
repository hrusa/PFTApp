using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Measure
    {
        public int id { get; set; }
        public int traineeId { get; set; }
        public int attributeId { get; set; }
        public DateTime date { get; set; }
        public int value { get; set; }

        public virtual Trainee trainee { get; set; }
        public virtual Attribute attribute { get; set; }
    }
}