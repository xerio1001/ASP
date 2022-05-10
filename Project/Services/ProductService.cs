using MongoDB.Driver;
using Project.Models;

namespace Project.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<ProductModel> _products;
        private readonly IMongoCollection<SupplierModel> _suppliers;

        public ProductService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Project");
            _products = database.GetCollection<ProductModel>("stock");
            _suppliers = database.GetCollection<SupplierModel>("supplier");
        }

        public List<ProductModel> GetAllProducts()
        {
            return _products.Find(products => true).ToList();
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

        public List<ProductModel> GetProductBySupplier(string id)
        {
            return _products.Find(products => products.SupplierId == id).ToList();
        }

        public List<string> GetSupplierByName(string id)
        {
            List<string> listSuppliers = new();
            List<SupplierModel> suppliers = _suppliers.Find(supplier => true).ToList();
            ProductModel product = _products.Find(product => product.Id == id).FirstOrDefault();

            listSuppliers = suppliers.Where(c => product.SupplierId.Contains(c.Id)).Select(c => c.Supplier).ToList();

            return listSuppliers;
        }
    }
}
