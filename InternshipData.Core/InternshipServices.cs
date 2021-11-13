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
        /// <returns> containing the list of object</returns>
        public List<Data> GetInternships()
        {
            List<Data> data = new List<Data>();
            
            var list = _internships.Find(internships => true).ToList();
            foreach (var item in list)
            {
                var comp = GetCompanyById(item.CompanyId);
                var disc = GetDisciplineById(item.DisciplineId);
                var loc = GetLocationById(item.LocationId);
                var rate = GetRatingById(item.RatingId);
                var vo = GetVoteById(item.Id.ToString());

                item.votes = vo.Total;

                data.Add(new Data
                    {
                        internship = item,
                        company = comp,
                        discipline = disc,
                        location = loc,
                        rating = rate,
                        vote = vo
                    }
                );
            }
            return data;
        }

        /// <summary>
        /// Retrieves List of Companies from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public List<Company> GetCompanies()
        {
            var list = _companies.Find(companies => true).ToList();
            return list;
        }

        /// <summary>
        /// Retrieves Company Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Company GetCompanyById(string id)
        {
            var filter = Builders<Company>.Filter.Eq("_id", new ObjectId(id));
            var comp = _companies.Find(filter).First();
            return comp;
        }

        /// <summary>
        /// Retrieves List of Disciplines from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public List<Discipline> GetDisciplines()
        {
            var list = _disciplines.Find(discipline => true).ToList();
            return list;
        }

        /// <summary>
        /// Retrieves Discipline Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Discipline GetDisciplineById(string id)
        {
            var filter = Builders<Discipline>.Filter.Eq("_id", new ObjectId(id));
            var disc = _disciplines.Find(filter).First();
            return disc;
        }

        /// <summary>
        /// Retrieves List of Locations from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public List<Location> GetLocations()
        {
            var list = _locations.Find(location => true).ToList();
            return list;
        }

        /// <summary>
        /// Retrieves Location Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Location GetLocationById(string id)
        {
            var filter = Builders<Location>.Filter.Eq("_id", new ObjectId(id));
            var loc = _locations.Find(filter).First();
            return loc;
        }

        /// <summary>
        /// Retrieves List of Ratings from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public List<Rating> GetRatings()
        {
            var rate = _ratings.Find(r => true).ToList();
            return rate;
        }

        /// <summary>
        /// Retrieves Rating Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Rating GetRatingById(string id)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", new ObjectId(id));
            var rate = _ratings.Find(filter).First();
            return rate;
        }

        /// <summary>
        /// Retrieves List of Majors from the database
        /// </summary>
        /// <returns> containing the list of object</returns>
        public List<Major> GetMajors()
        {
            var list = _majors.Find(major => true).ToList();
            return list;
        }

        /// <summary>
        /// Retrieves Major Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Major GetMajorById(string id)
        {
            var filter = Builders<Major>.Filter.Eq("_id", new ObjectId(id));
            var maj = _majors.Find(filter).First();
            return maj;
        }

        /// <summary>
        /// Retrieves Vote Object by Id from database
        /// </summary>
        /// <param name="id">id to lookup</param>
        /// <returns> containing the object</returns>
        public Vote GetVoteById(string id)
        {
            var filter = Builders<Vote>.Filter.Eq("InternshipId", new ObjectId(id));
            var vote = _votes.Find(filter).First();
            return vote;
        }

        /// <summary>
        /// Adds internship and all corresponding data
        /// </summary>
        /// <param name="data">Data object containing internship info</param>
        /// <returns> containing the object</returns>
        public void AddInternship(Data data)
        {

            var companyResult = AddCompany(data.company);
            var disciplineResult = AddDiscipline(data.discipline);
            var locationResult = AddLocation(data.location);
            var ratingResult = AddRating(data.rating);
            //var userResult = GetUserId(data.user);

            data.internship.CompanyId = companyResult.Id.ToString();
            data.internship.DisciplineId = disciplineResult.Id.ToString();
            data.internship.LocationId = locationResult.Id.ToString();
            data.internship.RatingId = ratingResult.Id.ToString();
            //data.internship.UserId = userResult.Id.ToString();

            _internships.InsertOne(data.internship);

            var ship = _internships.Find(i => i.CreatedDate == data.internship.CreatedDate).First();

             AddVote(ship.Id.ToString());
        }

        /// <summary>
        /// Retrieves Company from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="company">Company object</param>
        /// <returns> containing the object</returns>
        public Company AddCompany(Company company)
        {
            bool exists = _companies.Find(c => c.CompanyName == company.CompanyName).Any();
            if (!exists)
            {
                 _companies.InsertOne(company);
            }

            var comp = _companies.Find(c => c.CompanyName == company.CompanyName).First();

            return comp;
        }

        /// <summary>
        /// Retrieves Discipline from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="discipline">Discipline object</param>
        /// <returns> containing the object</returns>
        public Discipline AddDiscipline(Discipline discipline)
        {
            bool exists = _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).Any();
            if (!exists)
            {
                 _disciplines.InsertOne(discipline);
            }

            var disc = _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).First();

            return disc;
        }

        /// <summary>
        /// Retrieves Location from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="location">Location object</param>
        /// <returns> containing the object</returns>
        public Location AddLocation(Location location)
        {
            bool exists = _locations.Find(l => l.City == location.City && l.State == location.State).Any();
            if (!exists)
            {
                 _locations.InsertOne(location);
            }

            var loc = _locations.Find(l => l.City == location.City && l.State == location.State).First();

            return loc;
        }

        /// <summary>
        /// Retrieves Major from database, if it doesn't exist it is inserted
        /// </summary>
        /// <param name="major">Major object</param>
        /// <returns> containing the object</returns>
        public Major AddMajor(Major major)
        {
            bool exists = _majors.Find(m => m.MajorName == major.MajorName).Any();
            if (!exists)
            {
                 _majors.InsertOne(major);
            }

            var maj = _majors.Find(m => m.MajorName == major.MajorName).First();

            return maj;
        }

        /// <summary>
        /// Retrieves Rating object if it is in the database
        /// </summary>
        /// <param name="rating">Rating to find if it exists, if not insert it</param>
        /// <returns> containing the object</returns>
        public Rating AddRating(Rating rating)
        {
            bool exists = _ratings.Find(r => r.RatingNumber == rating.RatingNumber).Any();
            if (!exists)
            {
                 _ratings.InsertOne(rating);
            }

            var rate = _ratings.Find(r => r.RatingNumber == rating.RatingNumber).First();

            return rate;
        }

        /// <summary>
        /// Inserts initial values for the votes create record
        /// </summary>
        /// <param name="internshipId">Id for Internship</param>
        /// <returns>/returns>
        public void AddVote(string internshipId)
        {
            bool exists = _votes.Find(v => v.InternshipId == internshipId).Any();
            if (!exists)
            {
                Vote vote = new Vote
                {
                    InternshipId = internshipId,
                    Total = 0
                };
                 _votes.InsertOne(vote);
            }

        }


        //public  UpdateVote(int internshipId, int total)
        //{
        //    var filter = Builders<Vote>.Filter.Eq(v => v.InternshipId, internshipId);
        //    var update = Builders<Vote>.Update.Set(v => v.Total, total);
        //     _votes.UpdateOne(filter, update);
        //}

    }
}
