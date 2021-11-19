using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class InternshipHeaders
    {
        [FromHeader]
        public Internship Internship { get; set; }

        [FromHeader]
        public Company Company { get; set; }

        [FromHeader]
        public Discipline Discipline { get; set; }

        [FromHeader]
        public Location Location { get; set; }
        [FromHeader]
        public Major Major { get; set; }
        [FromHeader]
        public Rating Rating { get; set; }
        [FromHeader]
        public Vote Vote { get; set; }
        [FromHeader]
        public User User { get; set; }
    }
}
