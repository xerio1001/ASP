using MongoDB.Driver;
using Project.Models;

namespace Project.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<ProductModel> _products;

        public ProductService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Project");
            _products = database.GetCollection<ProductModel>("stock");
        }

        public List<ProductModel> GetAllProducts()
        {
            return _products.Find(product => true).ToList();
        }

        public ProductModel GetOne(string id)
        {
            return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public ProductModel Create(ProductModel product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, ProductModel productIn)
        {
            _products.ReplaceOne(product => product.Id == id, productIn);
        }

        public void Remove(ProductModel productIn)
        {
            _products.DeleteOne(product => product.Id == productIn.Id);
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }
    }
}
