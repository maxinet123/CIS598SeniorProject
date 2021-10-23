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
        [BsonElement("rating")]
        public string Rating { get; set; }
        [BsonElement("vote")]
        public int Vote { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("locationId")]
        public int LocationId { get; set; }
        [BsonElement("disciplineId")]
        public int DisciplineId { get; set; }
        [BsonElement("companyId")]
        public int CompanyId { get; set; }
        //[BsonElement("userId")]
        //public ObjectId UserId { get; set; }
    }
}
