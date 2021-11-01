using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipData.Core.Models
{
    public class Rating
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("stars")] 
        public string Stars { get; set; }
        [BsonElement("rating")]
        public int RatingNumber { get; set; }
    }
}
