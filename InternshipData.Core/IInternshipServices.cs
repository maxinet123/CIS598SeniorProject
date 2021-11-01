using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public interface IInternshipServices
    {
        Task<List<Internship>> GetInternships();
        Task<List<Company>> GetCompanies();
        Task<List<Discipline>> GetDisciplines();
        Task<List<Location>> GetLocations();
        Task<List<Rating>> GetRatings();
        Task<List<Major>> GetMajors();
        Task AddInternship(Internship internship, Company company, Discipline discipline, Location location);
        Task UpdateVote(Vote vote);
        Task<Company> AddCompany(Company company);
        Task<Discipline> AddDiscipline(Discipline discipline);
        Task<Location> AddLocation(Location location);
        Task<Rating> AddRating(Rating rating);
        Task<Major> AddMajor(Major major);
    }
}
