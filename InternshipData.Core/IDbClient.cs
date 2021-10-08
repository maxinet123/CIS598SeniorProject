using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public interface IDbClient
    {
        IMongoCollection<Internship> GetInternshipCollection();
    }
}
