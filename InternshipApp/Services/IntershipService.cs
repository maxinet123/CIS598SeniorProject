using InternshipApp;
using InternshipApp.Models;
using MongoDB.Driver;
using senior_proj_backend.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IMongoCollection<Internship> _internships;
        public InternshipService(IDbClient dbClient)
        {
            _internships = dbClient.GetInternshipCollection();
        }
        public List<Internship> GetInternships()
        {
            throw new NotImplementedException();
        }
    }
}
