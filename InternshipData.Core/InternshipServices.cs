using MongoDB.Driver;
using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Globalization;

namespace InternshipData.Core
{
    public class InternshipServices : IInternshipServices
    {

        private readonly IMongoCollection<Internship> _internships;
        private readonly IMongoCollection<Company> _companies;
        private readonly IMongoCollection<Discipline> _disciplines;
        private readonly IMongoCollection<Location> _locations;
        private readonly IMongoCollection<Major> _majors;
        private readonly IMongoCollection<Rating> _ratings;
        private readonly IMongoCollection<Vote> _votes;
        private readonly IMongoCollection<User> _users;

        public InternshipServices(IDbClient dbClient)
        {
            _internships = dbClient.GetInternshipCollection();
            _companies = dbClient.GetCompanyCollection();
            _disciplines = dbClient.GetDisciplineCollection();
            _locations = dbClient.GetLocationCollection();
            _majors = dbClient.GetMajorCollection();
            _ratings = dbClient.GetRatingCollection();
            _votes = dbClient.GetVoteCollection();
            _users = dbClient.GetUserCollection();
        }

        /// <summary>
        /// Retrieves List of Data corresponding to the internships from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Data>> GetInternships()
        {
            List<Data> data = new List<Data>();
            
            var list = await _internships.Find(internships => true).ToListAsync();
            foreach (var item in list)
            {
                var comp = await GetCompanyById(item.CompanyId);
                var disc = await GetDisciplineById(item.DisciplineId);
                var loc = await GetLocationById(item.LocationId);
                var rate = await GetRatingById(item.RatingId);
                var maj = await GetMajorById(item.MajorId);
                var vo = await GetVoteById(item.VoteId);

                data.Add(new Data
                    {
                        InternshipId = item.Id,
                        Position = item.Position,
                        Description = item.Description,
                        IsRemote = item.IsRemote,
                        HasHousing = item.HasHousing,
                        Wage = item.Wage,
                        Votes = vo.Total,
                        Duration = item.Duration,
                        Stars = rate.Stars,
                        Rating = rate.RatingNumber,
                        City = loc.City,
                        State = loc.State,
                        ZipCode = loc.ZipCode,
                        Discipline = disc.DisciplineName,
                        Company = comp.CompanyName,
                        Major = maj.MajorName
                    }
                );
            }
            return data;
        }

        /// <summary>
        /// Retrieves List of Companies from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Company>> GetCompanies()
        {
            var list = await _companies.Find(companies => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Company Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Company> GetCompanyById(string id)
        {
            var filter = Builders<Company>.Filter.Eq("_id", id);
            var comp = await _companies.Find(filter).FirstAsync();
            return comp;
        }

        /// <summary>
        /// Retrieves List of Disciplines from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Discipline>> GetDisciplines()
        {
            var list = await _disciplines.Find(discipline => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Discipline Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Discipline> GetDisciplineById(string id)
        {
            var filter = Builders<Discipline>.Filter.Eq("_id", id);
            var disc = await _disciplines.Find(filter).FirstAsync();
            return disc;
        }

        /// <summary>
        /// Retrieves List of Locations from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Location>> GetLocations()
        {
            var list = await _locations.Find(location => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Location Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Location> GetLocationById(string id)
        {
            var filter = Builders<Location>.Filter.Eq("_id", id);
            var loc = await _locations.Find(filter).FirstAsync();
            return loc;
        }

        /// <summary>
        /// Retrieves List of Ratings from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Rating>> GetRatings()
        {
            var rate = await _ratings.Find(r => true).ToListAsync();
            return rate;
        }

        /// <summary>
        /// Retrieves Rating Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Rating> GetRatingById(string id)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", id);
            var rate = await _ratings.Find(filter).FirstAsync();
            return rate;
        }

        /// <summary>
        /// Retrieves List of Majors from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public async Task<List<Major>> GetMajors()
        {
            return await _majors.Find(major => true).ToListAsync();
        }

        /// <summary>
        /// Retrieves Major Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Major> GetMajorById(string id)
        {
            var filter = Builders<Major>.Filter.Eq("_id", id);
            var maj = await _majors.Find(filter).FirstAsync();
            return maj;
        }

        /// <summary>
        /// Retrieves User Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<User> GetUserById(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var user = await _users.Find(filter).FirstAsync();
            return user;
        }

        /// <summary>
        /// Retrieves Vote Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public async Task<Vote> GetVoteById(string id)
        {
            var filter = Builders<Vote>.Filter.Eq("_id", id);
            var vote = await _votes.Find(filter).FirstAsync();
            return vote;
        }

        /// <summary>
        /// Adds internship and all corresponding data
        /// </summary>
        /// <param name="data">Data object containing internship info</param>
        /// <returns> containing the object</returns>
        public async Task AddInternship(Internship internship, Company company, Location location, Major major, Discipline discipline, Rating rating, Vote vote, User user)
        {
            var result = await AddUser(user);
            internship.CompanyId = await AddCompany(company);
            internship.DisciplineId = await AddDiscipline(discipline);
            internship.LocationId = await AddLocation(location);
            internship.RatingId = await AddRating(rating);
            internship.VoteId = await AddVote(vote);
            internship.MajorId = await AddMajor(major);
            internship.UserId = result.Id;

            await _internships.InsertOneAsync(internship);
        }

        /// <summary>
        /// Retrieves Company from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="company">Company object</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddCompany(Company company)
        {
            var filter = Builders<Company>.Filter.Eq("CompanyName", company.CompanyName);
            bool exists = await _companies.Find(filter).AnyAsync();
            if (!exists)
            {
                 await _companies.InsertOneAsync(company);
            }

            var comp = await _companies.Find(filter).FirstAsync();

            return comp.Id;
        }

        /// <summary>
        /// Retrieves Discipline from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="discipline">Discipline object</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddDiscipline(Discipline discipline)
        {
            var filter = Builders<Discipline>.Filter.Eq("DisciplineName", discipline.DisciplineName);
            bool exists = await _disciplines.Find(filter).AnyAsync();
            if (!exists)
            {
                 await _disciplines.InsertOneAsync(discipline);
            }

            var disc = await _disciplines.Find(filter).FirstAsync();

            return disc.Id;
        }

        /// <summary>
        /// Retrieves Location from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="location">Location object</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddLocation(Location location)
        {
            var filter = Builders<Location>.Filter.Eq("City", location.City)
                    & Builders<Location>.Filter.Eq("State", location.State)
                    & Builders<Location>.Filter.Eq("ZipCode", location.ZipCode);
            bool exists = await _locations.Find(filter).AnyAsync();
            if (!exists)
            {
                 await _locations.InsertOneAsync(location);
            }

            var loc = await _locations.Find(filter).FirstAsync();

            return loc.Id;
        }

        /// <summary>
        /// Inserts Vote Obj in the database
        /// </summary>
        /// <param name="vote">Vote object</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddVote(Vote vote)
        {
            await _votes.InsertOneAsync(vote);

            return vote.Id;
        }

        /// <summary>
        /// Retrieves Major from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="major">Major object</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddMajor(Major major)
        {
            var filter = Builders<Major>.Filter.Eq("MajorName", major.MajorName);
            bool exists = await _majors.Find(filter).AnyAsync();
            if (!exists)
            {
                 await _majors.InsertOneAsync(major);
            }

            var maj = await _majors.Find(filter).FirstAsync();

            return maj.Id;
        }

        /// <summary>
        /// Retrieves Rating object if it is in the database
        /// </summary>
        /// <param name="rating">Rating to find if it exists, if not insert it</param>
        /// <returns> containing the object</returns>
        public async Task<string> AddRating(Rating rating)
        {
            var filter = Builders<Rating>.Filter.Eq("RatingNumber", rating.RatingNumber);
            bool exists = await _ratings.Find(filter).AnyAsync();
            if (!exists)
            {
                 await _ratings.InsertOneAsync(rating);
            }

            var rate = await _ratings.Find(filter).FirstAsync();

            return rate.Id;
        }

        /// <summary>
        /// Retrieves User from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns> containing the object</returns>
        public async Task<User> AddUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("Email", user.Email);
            bool exists = await _users.Find(filter).AnyAsync();
            if (!exists)
            {
                await _users.InsertOneAsync(user);
            }

            var u = await _users.Find(filter).FirstAsync();

            return u;
        }

        /// <summary>
        /// Updates values for the votes to increment/decrement votes
        /// </summary>
        /// <param name="id">id of vote object</param>
        /// <param name="total">current total</param>
        /// <returns></returns>
        public async Task UpdateVote(string id, int newTotal)
        {
            var filter = Builders<Vote>.Filter.Eq(v => v.Id, id);
            var update = Builders<Vote>.Update.Set(v => v.Total, newTotal);
            await _votes.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Retrieves Internship Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Updated internship object</returns>
        public async Task<Internship> GetInternshipById(string id)
        {
            var filter = Builders<Internship>.Filter.Eq("_id", id);
            var intern = await _internships.Find(filter).FirstAsync();

            return intern;
        }

    }
}
