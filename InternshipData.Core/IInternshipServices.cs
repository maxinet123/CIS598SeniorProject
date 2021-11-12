using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public interface IInternshipServices
    {
        Task<List<Data>> GetInternships();
        List<Company> GetCompanies();
        Task<Company> GetCompanyById(string id);
        Task<List<Discipline>> GetDisciplines();
        Task<Discipline> GetDisciplineById(string id);
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(string id);
        Task<List<Rating>> GetRatings();
        Task<Rating> GetRatingById(string id);
        Task<List<Major>> GetMajors();
        Task<Major> GetMajorById(string id);
        Task<Vote> GetVoteById(string id);
        Task AddInternship(Data data);
        Task<Company> AddCompany(Company company);
        Task<Discipline> AddDiscipline(Discipline discipline);
        Task<Location> AddLocation(Location location);
        Task<Major> AddMajor(Major major);
        Task<Rating> AddRating(Rating rating);
        Task AddVote(string internshipId);

    }
}
