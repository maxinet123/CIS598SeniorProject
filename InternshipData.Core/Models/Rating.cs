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
        [BsonElement("ratingNumber")]
        public int RatingNumber { get; set; }
    }
}
