using MongoDB.Driver;
using Project.Models;

namespace Project.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<SupplierModel> _suppliers;

        public SupplierService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Project");
            _suppliers = database.GetCollection<SupplierModel>("supplier");
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            return _suppliers.Find(supplier => true).ToList();
        }

        public SupplierModel GetOne(string id)
        {
            return _suppliers.Find(supplier => supplier.Id == id).FirstOrDefault();
        }

        public SupplierModel Create(SupplierModel supplier)
        {
            _suppliers.InsertOne(supplier);
            return supplier;
        }

        public void Update(string id, SupplierModel supplierIn)
        {
            _suppliers.ReplaceOne(supplier => supplier.Id == id, supplierIn);
        }

        public void Remove(SupplierModel supplierIn)
        {
            _suppliers.DeleteOne(supplier => supplier.Id == supplierIn.Id);
        }

        public void Remove(string id)
        {
            _suppliers.DeleteOne(supplier => supplier.Id == id);
        }
    }
}
