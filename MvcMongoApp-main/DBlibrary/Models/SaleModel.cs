using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBlibrary.Models
{
    public class SaleModel
    {
        // test 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("saleDate")]
        public DateTime SaleDate { get; set; }
        [BsonElement("items")]
        public List<ItemModel> Items { get; set; } = new();
        [BsonElement("storeLocation")]
        public string? Storelocation { get; set; }
        [BsonElement("customer")]
        public CustomerModel? Customer { get; set; }
        [BsonElement("couponUsed")]
        public bool CouponUsed { get; set; } = false;
        [BsonElement("purchaseMethod")]
        public string? PurchaseMethod { get; set; }

    }
}
