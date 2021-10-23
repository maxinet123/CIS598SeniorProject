using MongoDB.Driver;
using System;
using System.Collections.Generic;
using InternshipData.Core.Models;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public class InternshipServices : IInternshipServices
    {

        private readonly IMongoCollection<Internship> _internships;
        private readonly IMongoCollection<Company> _companies;
        private readonly IMongoCollection<Discipline> _disciplines;
        private readonly IMongoCollection<Location> _locations;
        public InternshipServices(IDbClient dbClient)
        {
            _internships = dbClient.GetInternshipCollection();
            _companies = dbClient.GetCompanyCollection();
            _disciplines = dbClient.GetDisciplineCollection();
            _locations = dbClient.GetLocationCollection();
        }
        public async Task<List<Internship>> GetInternships()
        {
            var list = await _internships.Find(internships => true).ToListAsync();
            return list;
        }
        public async Task AddInternship(Internship internship, Company company, Discipline discipline, Location location)
        {
            var companyResult = _companies.InsertOneAsync(company);
            var disciplineResult = _disciplines.InsertOneAsync(discipline);
            var locationResult = _locations.InsertOneAsync(location);

            internship.CompanyId = companyResult.Id;
            internship.DisciplineId = disciplineResult.Id;
            internship.LocationId = locationResult.Id;

            await _internships.InsertOneAsync(internship);
        }
    }
}
