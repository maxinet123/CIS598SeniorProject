using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipData.Core.Models
{
    public class Description
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("internshipId")]
        public int InternshipId { get; set; }
        [BsonElement("paragraph")]
        public string Paragraph { get; set; }
    }
}
