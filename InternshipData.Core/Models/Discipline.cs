using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core.Models
{
    public class Discipline
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("disciplineName")]
        public string DisciplineName { get; set; }
    }
}
