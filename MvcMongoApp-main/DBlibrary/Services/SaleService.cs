using DBlibrary.Models;
using MongoDB.Driver;

namespace DBlibrary.Services
{
    public class SaleService
    {
        private readonly IMongoCollection<SaleModel> sales;

        public SaleService()
        {
            MongoClient client = new MongoClient("mongodb+srv://app_user:app3707_Mon@sandbox.5sawf.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("sample_supplies");
            sales = database.GetCollection<SaleModel>("sales");
        }

        public List<SaleModel> Get()
        {
            return sales.Find(car => true).ToList();
        }

        public SaleModel Get(string id)
        {
            return sales.Find(car => car.Id == id).FirstOrDefault();
        }

        public SaleModel Create(SaleModel car)
        {
            sales.InsertOne(car);
            return car;
        }

        public void Update(string id, SaleModel carIn)
        {
            sales.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(SaleModel carIn)
        {
            sales.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            sales.DeleteOne(car => car.Id == id);
        }
    }
}
