using MongoDB.Driver;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<StudentModel> _students;
        private readonly IMongoCollection<CourseModel> _courses;

        public StudentService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("school-data");
            _students = database.GetCollection<StudentModel>("students");
            _courses = database.GetCollection<CourseModel>("courses");
        }

        public List<StudentModel> GetAllStudents()
        {
            return _students.Find(student => true).ToList();
        }

        public StudentModel GetOne(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public StudentModel Create(StudentModel student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, StudentModel studentIn)
        {
            _students.ReplaceOne(student => student.Id == id, studentIn);
        }

        public void Remove(StudentModel studentIn)
        {
            _students.DeleteOne(student => student.Id == studentIn.Id);
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public List<string> GetCoursesForStudent(string id)
        {
            List<string> listCourses = new List<string>();
            List<CourseModel> allCourses = _courses.Find(course => true).ToList();
            StudentModel student = _students.Find(student => student.Id == id).FirstOrDefault();

            listCourses = allCourses.Where(c => student.Courses.Contains(c.Id)).Select(c => c.Name).ToList();

            return listCourses;
        }

        public List<string> GetResultsForStudent(string id)
        {
            //List<string> listCourses = new List<string>();
            List<CourseModel> allCourses = _courses.Find(course => true).ToList();
            StudentModel student = _students.Find(student => student.Id == id).FirstOrDefault();

            List<string> listKeys = student.Results.Keys.ToList();

            return listKeys;
        }
    }
}
