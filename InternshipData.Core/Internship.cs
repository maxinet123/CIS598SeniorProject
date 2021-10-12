using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core
{
    public class Internship
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("location")]
        public string Location { get; set; }
        [BsonElement("discipline")]
        public string Discipline { get; set; }
        [BsonElement("companyName")]
        public string CompanyName { get; set; }
        [BsonElement("rating")]
        public int Rating { get; set; }
        [BsonElement("user")]
        public string User { get; set; }
        [BsonElement("isRemote")]
        public bool IsRemote { get; set; }
        [BsonElement("salary")]
        public double Salary { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate {get; set; }
        [BsonElement("endDate")]
        public DateTime EndDate {get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
