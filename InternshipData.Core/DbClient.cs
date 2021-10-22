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
        public DbClient(IOptions<InternshipDbConfig> internshipDbConfig)
        {
            var client = new MongoClient(internshipDbConfig.Value.Connection_String);
            var database = client.GetDatabase(internshipDbConfig.Value.Database_Name);
            _internships = database.GetCollection<Internship>(internshipDbConfig.Value.Internship_Collection_Name);
        }

        public IMongoCollection<Internship> GetInternshipCollection() => _internships;
    }
}
