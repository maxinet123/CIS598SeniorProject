using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class Data
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternshipId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public bool IsRemote { get; set; }
        public bool HasHousing { get; set; }
        public double Wage { get; set; }
        //public int Votes { get; set; }
        public string Duration { get; set; }
        public string Stars { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Discipline { get; set; }
        public string Company { get; set; }
        public string Major { get; set; }
    }
}
