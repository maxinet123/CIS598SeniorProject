using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core.Models
{
    public class Company
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("companyName")]
        public string CompanyName { get; set; }
    }
}
