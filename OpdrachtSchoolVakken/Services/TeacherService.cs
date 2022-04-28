using MongoDB.Driver;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Services
{
    public class TeacherService
    {
        private readonly IMongoCollection<TeacherModel> _teachers;

        public TeacherService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("school-data");
            _teachers = database.GetCollection<TeacherModel>("teachers");
        }

        public List<TeacherModel> GetAllTeachers()
        {
            return _teachers.Find(teacher => true).ToList();
        }

        public TeacherModel GetOne(string id)
        {
            return _teachers.Find(teacher => teacher.Id == id).FirstOrDefault();
        }

        public TeacherModel Create(TeacherModel car)
        {
            _teachers.InsertOne(car);
            return car;
        }

        public void Update(string id, TeacherModel teacherIn)
        {
            _teachers.ReplaceOne(teacher => teacher.Id == id, teacherIn);
        }

        public void Remove(TeacherModel teacherIn)
        {
            _teachers.DeleteOne(teacher => teacher.Id == teacherIn.Id);
        }

        public void Remove(string id)
        {
            _teachers.DeleteOne(teacher => teacher.Id == id);
        }
    }
}
