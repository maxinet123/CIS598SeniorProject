using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class InternshipHeaders
    {
        public Internship Internship { get; set; }
        public Company Company { get; set; }
        public Discipline Discipline { get; set; }
        public Location Location { get; set; }
        public Major Major { get; set; }
        public Rating Rating { get; set; }
        //public Vote Vote { get; set; }
        public User User { get; set; }
    }
}
