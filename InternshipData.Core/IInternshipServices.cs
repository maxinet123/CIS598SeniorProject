using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core
{
    public interface IInternshipServices
    {
        List<Internship> GetInternships();
        Internship AddInternship(Internship internship);
    }
}
