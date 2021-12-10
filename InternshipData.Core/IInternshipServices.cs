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
        Task<List<Data>> GetInternshipsByUserId(string id);
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompanyById(string id);
        Task<List<Discipline>> GetDisciplines();
        Task<Discipline> GetDisciplineById(string id);
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(string id);
        Task<List<Rating>> GetRatings();
        Task<Rating> GetRatingById(string id);
        Task<List<Major>> GetMajors();
        Task<Major> GetMajorById(string id);
        //Task<Vote> GetVoteById(string id);
        Task<User> GetUserById(string id);
        Task AddInternship(Internship internship, Company company, Location location, Major major, Discipline discipline, Rating rating, User user); //, Vote vote);
        Task<string> AddCompany(Company company);
        Task<string> AddDiscipline(Discipline discipline);
        Task<string> AddLocation(Location location);
        Task<string> AddMajor(Major major);
        //Task<string> AddVote(Vote vote);
        Task<string> AddRating(Rating rating);
        Task<User> AddUser(User user);
        //Task UpdateVote(string id, int newTotal);
        Task<Internship> GetInternshipById(string id);


    }
}
