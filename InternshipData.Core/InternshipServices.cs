using MongoDB.Driver;
using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Threading.Tasks;
using MongoDB.Bson;

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
        //private readonly IMongoCollection<User> _users;

        public InternshipServices(IDbClient dbClient)
        {
            _internships = dbClient.GetInternshipCollection();
            _companies = dbClient.GetCompanyCollection();
            _disciplines = dbClient.GetDisciplineCollection();
            _locations = dbClient.GetLocationCollection();
            _majors = dbClient.GetMajorCollection();
            _ratings = dbClient.GetRatingCollection();
            _votes = dbClient.GetVoteCollection();
            //_users = dbClient.GetUserCollection();
        }

        /// <summary>
        /// Retrieves List of Data corresponding to the internships from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public async Task<List<Data>> GetInternships()
        {
            List<Data> data = new List<Data>();
            
            var list = await _internships.Find(internships => true).ToListAsync();
            foreach (var item in list)
            {
                var comp = await GetCompanyById(item.CompanyId);
                var disc = await GetDisciplineById(item.DisciplineId);
                var loc = await GetLocationById(item.LocationId);
                //var rate = await GetRatingById(item.RatingId);
                var vote = await GetVoteById(item.Id.ToString());

                item.votes = vote.Total;

                data.Add(new Data
                    {
                        internship = item,
                        company = comp,
                        discipline = disc,
                        location = loc,
                        //rating = rate,
                    }
                );
            }
            return data;
        }

        /// <summary>
        /// Retrieves List of Companies from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public List<Company> GetCompanies()
        {
            var list = _companies.Find(companies => true).ToList();
            return list;
        }

        /// <summary>
        /// Retrieves Company Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Company> GetCompanyById(string id)
        {
            var comp = await _companies.Find(c => c.Id.ToString() == id).FirstAsync();
            return comp;
        }

        /// <summary>
        /// Retrieves List of Disciplines from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public async Task<List<Discipline>> GetDisciplines()
        {
            var list = await _disciplines.Find(discipline => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Discipline Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Discipline> GetDisciplineById(string id)
        {
            var disc = await _disciplines.Find(d => d.Id.ToString() == id).FirstAsync();
            return disc;
        }

        /// <summary>
        /// Retrieves List of Locations from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public async Task<List<Location>> GetLocations()
        {
            var list = await _locations.Find(location => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Location Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Location> GetLocationById(string id)
        {
            var loc = await _locations.Find(l => l.Id.ToString() == id).FirstAsync();
            return loc;
        }

        /// <summary>
        /// Retrieves List of Ratings from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public async Task<List<Rating>> GetRatings()
        {
            var rate = await _ratings.Find(r => true).ToListAsync();
            return rate;
        }

        /// <summary>
        /// Retrieves Rating Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Rating> GetRatingById(string id)
        {
            var rate = await _ratings.Find(r => r.Id.ToString() == id).FirstAsync();
            return rate;
        }

        /// <summary>
        /// Retrieves List of Majors from the database
        /// </summary>
        /// <returns>Task containing the list of object</returns>
        public async Task<List<Major>> GetMajors()
        {
            var list = await _majors.Find(major => true).ToListAsync();
            return list;
        }

        /// <summary>
        /// Retrieves Major Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Major> GetMajorById(string id)
        {
            var maj = await _majors.Find(m => m.Id.ToString() == id).FirstAsync();
            return maj;
        }

        /// <summary>
        /// Retrieves Vote Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns>Task containing the object</returns>
        public async Task<Vote> GetVoteById(string id)
        {
            var vote = await _votes.Find(v => v.InternshipId == id).FirstAsync();
            return vote;
        }

        /// <summary>
        /// Adds internship and all corresponding data
        /// </summary>
        /// <param name="data">Data object containing internship info</param>
        /// <returns>Task containing the object</returns>
        public async Task AddInternship(Data data)
        {

            var companyResult = AddCompany(data.company).GetAwaiter().GetResult();
            var disciplineResult = AddDiscipline(data.discipline).GetAwaiter().GetResult();
            var locationResult = AddLocation(data.location).GetAwaiter().GetResult();
            //var ratingResult = AddRating(data.rating).GetAwaiter().GetResult();
            //var userResult = GetUserId(data.user);

            data.internship.CompanyId = companyResult.Id.ToString();
            data.internship.DisciplineId = disciplineResult.Id.ToString();
            data.internship.LocationId = locationResult.Id.ToString();
            //data.internship.RatingId = ratingResult.Id.ToString();
            //data.internship.UserId = userResult.Result.Id.ToString();

            await _internships.InsertOneAsync(data.internship);

            var ship = await _internships.Find(i => i.CreatedDate == data.internship.CreatedDate).FirstAsync();

            await AddVote(ship.Id.ToString());
        }

        /// <summary>
        /// Retrieves Company from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="company">Company object</param>
        /// <returns>Task containing the object</returns>
        public async Task<Company> AddCompany(Company company)
        {
            bool exists = await _companies.Find(c => c.CompanyName == company.CompanyName).AnyAsync();
            if (!exists)
            {
                await _companies.InsertOneAsync(company);
            }

            var comp = await _companies.Find(c => c.CompanyName == company.CompanyName).FirstAsync();

            return comp;
        }

        /// <summary>
        /// Retrieves Discipline from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="discipline">Discipline object</param>
        /// <returns>Task containing the object</returns>
        public async Task<Discipline> AddDiscipline(Discipline discipline)
        {
            bool exists = await _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).AnyAsync();
            if (!exists)
            {
                await _disciplines.InsertOneAsync(discipline);
            }

            var disc = await _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).FirstAsync();

            return disc;
        }

        /// <summary>
        /// Retrieves Location from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="location">Location object</param>
        /// <returns>Task containing the object</returns>
        public async Task<Location> AddLocation(Location location)
        {
            bool exists = await _locations.Find(l => l.City == location.City && l.State == location.State).AnyAsync();
            if (!exists)
            {
                await _locations.InsertOneAsync(location);
            }

            var loc = await _locations.Find(l => l.City == location.City && l.State == location.State).FirstAsync();

            return loc;
        }

        /// <summary>
        /// Retrieves Major from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="major">Major object</param>
        /// <returns>Task containing the object</returns>
        public async Task<Major> AddMajor(Major major)
        {
            bool exists = await _majors.Find(m => m.MajorName == major.MajorName).AnyAsync();
            if (!exists)
            {
                await _majors.InsertOneAsync(major);
            }

            var maj = await _majors.Find(m => m.MajorName == major.MajorName).FirstAsync();

            return maj;
        }

        /// <summary>
        /// Retrieves Rating object if it is in the database
        /// </summary>
        /// <param name="rating">Rating to find if it exists, if not insert it</param>
        /// <returns>Task containing the object</returns>
        public async Task<Rating> AddRating(Rating rating)
        {
            bool exists = await _ratings.Find(r => r.RatingNumber == rating.RatingNumber).AnyAsync();
            if (!exists)
            {
                await _ratings.InsertOneAsync(rating);
            }

            var rate = await _ratings.Find(r => r.RatingNumber == rating.RatingNumber).FirstAsync();

            return rate;
        }

        /// <summary>
        /// Inserts initial values for the votes create record
        /// </summary>
        /// <param name="internshipId">Id for Internship</param>
        /// <returns>Task</returns>
        public async Task AddVote(string internshipId)
        {
            bool exists = await _votes.Find(v => v.InternshipId == internshipId).AnyAsync();
            if (!exists)
            {
                Vote vote = new Vote
                {
                    InternshipId = internshipId,
                    Total = 0
                };
                await _votes.InsertOneAsync(vote);
            }

        }


        //public async Task UpdateVote(int internshipId, int total)
        //{
        //    var filter = Builders<Vote>.Filter.Eq(v => v.InternshipId, internshipId);
        //    var update = Builders<Vote>.Update.Set(v => v.Total, total);
        //    await _votes.UpdateOneAsync(filter, update);
        //}

    }
}
