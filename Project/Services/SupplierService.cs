using MongoDB.Driver;
using Project.Models;

namespace Project.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<SupplierModel> _suppliers;
        private readonly IMongoCollection<ProductModel> _products;

        public SupplierService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Project");
            _suppliers = database.GetCollection<SupplierModel>("supplier");
            _products = database.GetCollection<ProductModel>("stock");
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

        public List<SupplierModel> GetSupplierWithoutEnoughStock()
        {
            List<SupplierModel> filteredSupplier = new();
            List<SupplierModel> suppliers = _suppliers.Find(supplier => true).ToList();

            foreach (SupplierModel supplier in suppliers)
            {
                List<ProductModel> result = _products.Find(p => p.SupplierId == supplier.Id && p.AmountInStock <= 5 && p.Ordered == false).ToList();
                if (result.Count > 0)
                {
                    filteredSupplier.Add(supplier);
                }
            }

            return filteredSupplier;
        }

        public List<ProductModel> GetItemOfPickedSupplier(string id)
        {
            List<ProductModel> products = _products.Find(product => product.SupplierId == id && product.AmountInStock <= 5 && product.Ordered == false).ToList();

            return products;
        }

        public string GetSupplierMail(string id)
        {
            SupplierModel supplier = _suppliers.Find(s => s.Id == id).FirstOrDefault();

            return supplier.EmailAddress;
        }
    }
}
