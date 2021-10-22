using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipData.Core.Models;

namespace InternshipData.Core.Models
{
    public class Internship
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        public Description Description { get; set; }
        public Location Location { get; set; }
        public Discipline Discipline { get; set; }
        public Company Company { get; set; }
        public Vote Vote { get; set; }
        public User User { get; set; }
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
