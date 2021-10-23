using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public interface IInternshipServices
    {
        public async Task<List<Internship>> GetInternships();
        public async Task AddInternship(Internship internship, Company company, Discipline discipline, Location location);
    }
}
