using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace Project.Models
{
    [BsonIgnoreExtraElements]
    public class SupplierModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Naam")]
        [BsonElement("supplier")]
        public string Supplier { get; set; }

        [DisplayName("Adres")]
        [BsonElement("address")]
        public string Address { get; set; }

        [DisplayName("Telefoonnummer")]
        [BsonElement("phoneNumber")]
        public string Phonenumber { get; set; }

        [DisplayName("Email")]
        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
