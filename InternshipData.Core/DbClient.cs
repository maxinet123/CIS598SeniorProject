using Microsoft.Extensions.Options;
using MongoDB.Driver;
using InternshipData.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Internship> _internships;
        private readonly IMongoCollection<Company> _companies;
        private readonly IMongoCollection<Discipline> _disciplines;
        private readonly IMongoCollection<Location> _locations;
        public DbClient(IOptions<InternshipDbConfig> internshipDbConfig)
        {
            var client = new MongoClient(internshipDbConfig.Value.Connection_String);
            var database = client.GetDatabase(internshipDbConfig.Value.Database_Name);
            _internships = database.GetCollection<Internship>(internshipDbConfig.Value.Internship_Collection_Name);
            _companies = database.GetCollection<Company>(internshipDbConfig.Value.Company_Collection_Name);
            _disciplines = database.GetCollection<Discipline>(internshipDbConfig.Value.Discipline_Collection_Name);
            _locations = database.GetCollection<Location>(internshipDbConfig.Value.Location_Collection_Name);
        }

        public IMongoCollection<Internship> GetInternshipCollection() => _internships;
        public IMongoCollection<Company> GetCompanyCollection() => _companies;
        public IMongoCollection<Discipline> GetDisciplineCollection() => _disciplines;
        public IMongoCollection<Location> GetLocationCollection() => _locations;
    }
}
