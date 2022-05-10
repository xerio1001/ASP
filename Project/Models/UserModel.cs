using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace Project.Models
{
    [BsonIgnoreExtraElements]
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [DisplayName("Wachtwoord")]
        [BsonElement("password")]
        public string Password { get; set; }
    }
}
