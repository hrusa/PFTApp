using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFTApp.Models
{
    public class Attribute
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Measure> measures { get; set; }
    }
}