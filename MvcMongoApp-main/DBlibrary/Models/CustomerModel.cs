using MongoDB.Bson.Serialization.Attributes;

namespace DBlibrary.Models
{
    public class CustomerModel
    {
        [BsonElement("gender")]
        public string? Gender { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("satisfaction")]
        public int Satisfaction { get; set; }
    }
}
