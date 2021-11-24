using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core.Models
{
    public class Major
    {
        [BsonId] 
        public ObjectId Id { get; set; }
        [BsonElement("Major")]
        public string MajorName { get; set; }
        [BsonElement("Major_Category")]
        public string MajorCategory { get; set; }
    }
}
