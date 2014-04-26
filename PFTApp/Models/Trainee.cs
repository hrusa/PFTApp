using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PFTApp.Models
{
    public class Trainee
    {
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public DateTime birth { get; set; }
        public int gender { get; set; }
        public int experience { get; set; }
        public int goal { get; set; }

        public virtual ICollection<Training> trainings { get; set; }
    }
}