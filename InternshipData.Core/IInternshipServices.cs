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
        Company GetCompanyById(ObjectId id);
        List<Discipline> GetDisciplines();
        Discipline GetDisciplineById(ObjectId id);
        List<Location> GetLocations();
        Location GetLocationById(ObjectId id);
        List<Rating> GetRatings();
        Rating GetRatingById(ObjectId id);
        List<Major> GetMajors();
        Major GetMajorById(ObjectId id);
        Vote GetVoteById(ObjectId id);
        void AddInternship(Data data);
        Company AddCompany(Company company);
        Discipline AddDiscipline(Discipline discipline);
        Location AddLocation(Location location);
        Major AddMajor(Major major);
        Rating AddRating(Rating rating);
        void AddVote(ObjectId internshipId);
        void UpdateVote(Internship internship);
        Internship GetInternshipById(ObjectId id);


    }
}
