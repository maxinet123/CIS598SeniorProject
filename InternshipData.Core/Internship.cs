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
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        //public Location Location { get; set; }
        //public Discipline Discipline { get; set; }
        //public Company CompanyName { get; set; }
        //public Rating Rating { get; set; }
        //public User User { get; set; }
        //public bool IsRemote { get; set; }
        //public double Salary { get; set; }
        //public DateTime StartDate {get; set;}
        //public DateTime EndDate {get; set; }
        //public DateTime CreatedDate { get; set; }
    }
}
