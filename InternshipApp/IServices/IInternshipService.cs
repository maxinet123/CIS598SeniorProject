using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.IServices
{
    public interface IInternshipService
    {
        List<Internship> GetInternships();
    }
}
