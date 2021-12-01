using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace InternshipData.Core
{
    public interface IInternshipServices
    {
        Task<List<Data>> GetInternships();
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompanyById(ObjectId id);
        Task<List<Discipline>> GetDisciplines();
        Task<Discipline> GetDisciplineById(ObjectId id);
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(ObjectId id);
        Task<List<Rating>> GetRatings();
        Task<Rating> GetRatingById(ObjectId id);
        Task<List<Major>> GetMajors();
        Task<Major> GetMajorById(ObjectId id);
        Task<Vote> GetVoteById(ObjectId id);
        Task<User> GetUserById(ObjectId id);
        Task AddInternship(Internship internship, Company company, Location location, Major major, Discipline discipline, Rating rating, User user);
        Task<Company> AddCompany(Company company);
        Task<Discipline> AddDiscipline(Discipline discipline);
        Task<Location> AddLocation(Location location);
        Task<Major> AddMajor(Major major);
        Task<Rating> AddRating(Rating rating);
        Task AddVote(ObjectId internshipId);
        Task<User> AddUser(User user);
        Task UpdateVote(Data internship);
        Task<Internship> GetInternshipById(ObjectId id);


    }
}
