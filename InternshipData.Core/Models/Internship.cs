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
        public int votes { get; set; }
        [BsonElement("duration")]
        public string Duration { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("ratingId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId RatingId { get; set; }
        [BsonElement("locationId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId LocationId { get; set; }
        [BsonElement("disciplineId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId DisciplineId { get; set; }
        [BsonElement("companyId")]
        public ObjectId CompanyId { get; set; }
        //[BsonElement("userId")]
        //public ObjectId UserId { get; set; }
    }
}
