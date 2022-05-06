using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace Project.Models
{
    [BsonIgnoreExtraElements]
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Naam")]
        [BsonElement("name")]
        public string Name { get; set; }

        [DisplayName("Merk")]
        [BsonElement("brand")]
        public string Brand { get; set; }

        [DisplayName("In Stock")]
        [BsonElement("amountInStock")]
        public int AmountInStock { get; set; }

        [DisplayName("Leverancier")]
        [BsonElement("supplier")]
        public string SupplierId { get; set; }

        [DisplayName("Barcode")]
        [BsonElement("barcode")]
        public string Barcode { get; set; }
    }
}
