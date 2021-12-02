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
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("position")]
        public string Position { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("isRemote")]
        public bool IsRemote { get; set; }
        [BsonElement("hasHousing")]
        public bool HasHousing { get; set; }
        [BsonElement("wage")]
        public double Wage { get; set; }
        [BsonElement("votes")]
        public int Votes { get; set; }
        [BsonElement("duration")]
        public string Duration { get; set; }
        [BsonElement("ratingId")]
        public string RatingId { get; set; }
        [BsonElement("locationId")]
        public string LocationId { get; set; }
        [BsonElement("disciplineId")]
        public string DisciplineId { get; set; }
        [BsonElement("companyId")]
        public string CompanyId { get; set; }
        [BsonElement("voteId")]
        public string VoteId { get; set; }
        [BsonElement("majorId")]
        public string MajorId { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
    }
}
