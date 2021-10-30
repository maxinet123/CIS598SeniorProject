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

            var companyResult = AddCompany(company);
            var disciplineResult = AddDiscipline(discipline);
            var locationResult = AddLocation(location);

            internship.CompanyId = companyResult.Result.Id.ToString();
            internship.DisciplineId = disciplineResult.Result.Id.ToString();
            internship.LocationId = locationResult.Result.Id.ToString();

            await _internships.InsertOneAsync(internship);
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
    }
}
