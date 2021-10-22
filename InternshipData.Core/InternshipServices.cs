using MongoDB.Driver;
using System;
using System.Collections.Generic;
using InternshipData.Core.Models;

namespace InternshipData.Core
{
    public class InternshipServices : IInternshipServices
    {

        private readonly IMongoCollection<Internship> _internships;
        public InternshipServices(IDbClient dbClient)
        {
            _internships = dbClient.GetInternshipCollection();
        }
        public List<Internship> GetInternships()
        {
            return _internships.Find(internships => true).ToList();
        }
        public Internship AddInternship(Internship internship)
        {
            _internships.InsertOne(internship);
            return internship;
        }
    }
}
