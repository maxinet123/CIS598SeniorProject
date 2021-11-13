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
        List<Data> GetInternships();
        List<Company> GetCompanies();
        Company GetCompanyById(string id);
        List<Discipline> GetDisciplines();
        Discipline GetDisciplineById(string id);
        List<Location> GetLocations();
        Location GetLocationById(string id);
        List<Rating> GetRatings();
        Rating GetRatingById(string id);
        List<Major> GetMajors();
        Major GetMajorById(string id);
        Vote GetVoteById(string id);
        void AddInternship(Data data);
        Company AddCompany(Company company);
        Discipline AddDiscipline(Discipline discipline);
        Location AddLocation(Location location);
        Major AddMajor(Major major);
        Rating AddRating(Rating rating);
        void AddVote(string internshipId);

    }
}
