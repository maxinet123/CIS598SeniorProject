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
                var vote = await GetVoteById(item.VoteId);

                data.Add(new Data
                    {
                        internship = item,
                        company = comp,
                        discipline = disc,
                        location = loc,
                        rating = rate,
                        vote = vote
                    }
                );
            }
            return data;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var list = await _companies.Find(companies => true).ToListAsync();
            return list;
        }

        public async Task<Company> GetCompanyById(string id)
        {
            var comp = await _companies.Find(c => c.Id.ToString() == id).FirstAsync();
            return comp;
        }

        public async Task<List<Discipline>> GetDisciplines()
        {
            var list = await _disciplines.Find(discipline => true).ToListAsync();
            return list;
        }

        public async Task<Discipline> GetDisciplineById(string id)
        {
            var disc = await _disciplines.Find(d => d.Id.ToString() == id).FirstAsync();
            return disc;
        }

        public async Task<List<Location>> GetLocations()
        {
            var list = await _locations.Find(location => true).ToListAsync();
            return list;
        }

        public async Task<Location> GetLocationById(string id)
        {
            var loc = await _locations.Find(l => l.Id.ToString() == id).FirstAsync();
            return loc;
        }

        public async Task<List<Rating>> GetRatings()
        {
            var list = await _ratings.Find(rating => true).ToListAsync();
            return list;
        }

        public async Task<Rating> GetRatingById(string id)
        {
            var rate = await _ratings.Find(r => r.Id.ToString() == id).FirstAsync();
            return rate;
        }

        public async Task<List<Major>> GetMajors()
        {
            var list = await _majors.Find(major => true).ToListAsync();
            return list;
        }

        public async Task<Major> GetMajorById(string id)
        {
            var maj = await _majors.Find(m => m.Id.ToString() == id).FirstAsync();
            return maj;
        }

        public async Task<Vote> GetVoteById(string id)
        {
            var vote = await _votes.Find(v => v.Id.ToString() == id).FirstAsync();
            return vote;
        }

        public async Task AddInternship(Data data)
        {

            var companyResult = AddCompany(data.company).GetAwaiter().GetResult();
            var disciplineResult = AddDiscipline(data.discipline).GetAwaiter().GetResult();
            var locationResult = AddLocation(data.location).GetAwaiter().GetResult();
            //var ratingResult = GetRatingId(data.rating).GetAwaiter().GetResult();
            var voteResult = AddVote(data.vote).GetAwaiter().GetResult();
            //var userResult = GetUserId(data.user);

            data.internship.CompanyId = companyResult.Id.ToString();
            data.internship.DisciplineId = disciplineResult.Id.ToString();
            data.internship.LocationId = locationResult.Id.ToString();
            //data.internship.RatingId = ratingResult.Id.ToString();
            data.internship.VoteId = voteResult.Id.ToString();
            //data.internship.UserId = userResult.Result.Id.ToString();

            await _internships.InsertOneAsync(data.internship);

        }

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

        public async Task<Vote> AddVote(Vote vote)
        {
            bool exists = await _votes.Find(v => v.LkpKey == vote.LkpKey).AnyAsync();
            if (!exists)
            {
                await _votes.InsertOneAsync(vote);
            }

            var vo = await _votes.Find(v => v.LkpKey == vote.LkpKey).FirstAsync();

            return vo;
        }

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

        public async Task<Rating> GetRatingId(Rating rating)
        {
            var rate = await _ratings.Find(r => r.RatingNumber == rating.RatingNumber).FirstAsync();

            return rate;
        }


        //public async Task UpdateVote(int internshipId, int total)
        //{
        //    var filter = Builders<Vote>.Filter.Eq(v => v.InternshipId, internshipId);
        //    var update = Builders<Vote>.Update.Set(v => v.Total, total);
        //    await _votes.UpdateOneAsync(filter, update);
        //}

    }
}
