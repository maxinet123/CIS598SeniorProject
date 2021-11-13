using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class Vote
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("internshipId")]
        public ObjectId InternshipId { get; set; }
        [BsonElement("total")]
        public int Total { get; set; }
    }
}
