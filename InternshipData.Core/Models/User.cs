using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("fullName")]
        public string FullName {get; set; }
        [BsonElement("userName")]
        public string UserName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("majorId")]
        public ObjectId Major { get; set; }
    }
}
