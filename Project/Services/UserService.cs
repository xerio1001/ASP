using MongoDB.Driver;
using Project.Models;

namespace Project.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Project");
            _users = database.GetCollection<UserModel>("user");
        }

        public List<UserModel> GetAllUsers()
        {
            return _users.Find(products => true).ToList();
        }

        public void Create(string email, string password)
        {
            UserModel userSecured = new();

            userSecured.Password = BCrypt.Net.BCrypt.HashPassword(password);
            userSecured.Email = email;

            _users.InsertOne(userSecured);
        }
    }
}
