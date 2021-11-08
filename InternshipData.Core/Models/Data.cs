using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class Data
    {
        public Internship internship { get; set; }
        public Company company { get; set; }
        public Discipline discipline { get; set; }
        public Location location { get; set; }
        public Rating rating { get; set; }
        public Vote vote { get; set; }
    }
}
