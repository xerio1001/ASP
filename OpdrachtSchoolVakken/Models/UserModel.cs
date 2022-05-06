using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace OpdrachtSchoolVakken.Models
{
    [BsonIgnoreExtraElements]
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Name")]
        [BsonElement("name")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
