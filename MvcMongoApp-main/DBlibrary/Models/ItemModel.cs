using MongoDB.Bson.Serialization.Attributes;

namespace DBlibrary.Models
{
    public class ItemModel
    {
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new List<string>();
        [BsonElement("price")]
        public float Price { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
