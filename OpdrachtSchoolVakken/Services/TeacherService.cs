using MongoDB.Driver;
using OpdrachtSchoolVakken.Models;

namespace DBlibrary.Services
{
    public class TeacherService
    {
        private readonly IMongoCollection<TeacherModel> teachers;

        public TeacherService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("school-data");
            teachers = database.GetCollection<TeacherModel>("students");
        }

        public List<TeacherModel> Get()
        {
            return teachers.Find(car => true).ToList();
        }

        public TeacherModel Get(string id)
        {
            return teachers.Find(car => car.Id == id).FirstOrDefault();
        }

        public TeacherModel Create(TeacherModel car)
        {
            teachers.InsertOne(car);
            return car;
        }

        public void Update(string id, TeacherModel carIn)
        {
            teachers.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(TeacherModel carIn)
        {
            teachers.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            teachers.DeleteOne(car => car.Id == id);
        }
    }
}
