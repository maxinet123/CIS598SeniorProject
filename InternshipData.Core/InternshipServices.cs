﻿using MongoDB.Driver;
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

        public async Task<List<Internship>> GetInternships()
        {
            var list = await _internships.Find(internships => true).ToListAsync();

            return list;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var list = await _companies.Find(companies => true).ToListAsync();
            return list;
        }

        public async Task<List<Discipline>> GetDisciplines()
        {
            var list = await _disciplines.Find(discipline => true).ToListAsync();
            return list;
        }

        public async Task<List<Location>> GetLocations()
        {
            var list = await _locations.Find(location => true).ToListAsync();
            return list;
        }

        public async Task<List<Rating>> GetRatings()
        {
            var list = await _ratings.Find(rating => true).ToListAsync();
            return list;
        }

        public async Task<List<Major>> GetMajors()
        {
            var list = await _majors.Find(major => true).ToListAsync();
            return list;
        }


        public async Task AddInternship(Internship internship, Company company, Discipline discipline, Location location, Rating rating, Vote vote)
        {

            var companyResult = AddCompany(company);
            var disciplineResult = AddDiscipline(discipline);
            var locationResult = AddLocation(location);
            var ratingResult = GetRatingId(rating);

            internship.CompanyId = companyResult.Result.Id.ToString();
            internship.DisciplineId = disciplineResult.Result.Id.ToString();
            internship.LocationId = locationResult.Result.Id.ToString();
            internship.RatingId = ratingResult.Result.Id.ToString();

            await _internships.InsertOneAsync(internship);

            await InsertVoteDetails(vote, internship.LkpKey);
        }

        public async Task<Company> AddCompany(Company company)
        {
            bool exists = await _companies.Find(c => c.CompanyName == company.CompanyName).AnyAsync();
            if (!exists)
            {
                await _companies.InsertOneAsync(company);
            }

            var comp = await _companies.Find(c => c.CompanyName == company.CompanyName).FirstOrDefaultAsync();

            return comp;
        }

        public async Task<Discipline> AddDiscipline(Discipline discipline)
        {
            bool exists = await _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).AnyAsync();
            if (!exists)
            {
                await _disciplines.InsertOneAsync(discipline);
            }

            var disc = await _disciplines.Find(d => d.DisciplineName == discipline.DisciplineName).FirstOrDefaultAsync();

            return disc;
        }

        public async Task<Location> AddLocation(Location location)
        {
            bool exists = await _locations.Find(l => l.City == location.City && l.State == location.State).AnyAsync();
            if (!exists)
            {
                await _locations.InsertOneAsync(location);
            }

            var loc = await _locations.Find(l => l.City == location.City && l.State == location.State).FirstOrDefaultAsync();

            return loc;
        }

        public async Task<Major> AddMajor(Major major)
        {
            bool exists = await _majors.Find(m => m.MajorName == major.MajorName).AnyAsync();
            if (!exists)
            {
                await _majors.InsertOneAsync(major);
            }

            var maj = await _majors.Find(m => m.MajorName == major.MajorName).FirstOrDefaultAsync();

            return maj;
        }

        public async Task InsertVoteDetails(Vote vote, string key)
        {
            bool exists = await _votes.Find(v => v.InternshipId == vote.InternshipId).AnyAsync();
            if (!exists)
            {
                var internship = await _internships.Find(i => i.LkpKey == key).FirstOrDefaultAsync();

                vote.InternshipId = internship.Id;

                await _votes.InsertOneAsync(vote);
            }

        }

        public async Task<Rating> GetRatingId(Rating rating)
        {
            var rate = await _ratings.Find(r => r.RatingNumber == rating.RatingNumber).FirstOrDefaultAsync();

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
