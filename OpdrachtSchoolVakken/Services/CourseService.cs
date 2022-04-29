using MongoDB.Bson;
using MongoDB.Driver;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<CourseModel> _courses;
        private readonly IMongoCollection<StudentModel> _students;

        public CourseService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("school-data");
            _courses = database.GetCollection<CourseModel>("courses");
            _students = database.GetCollection<StudentModel>("students");
        }

        public List<CourseModel> GetAllCourses()
        {
            return _courses.Find(course => true).ToList();
        }

        public CourseModel GetOne(string id)
        {
            return _courses.Find(course => course.Id == id).FirstOrDefault();
        }

        public CourseModel Create(CourseModel course)
        {
            _courses.InsertOne(course);
            return course;
        }

        public void Update(string id, CourseModel courseIn)
        {
            _courses.ReplaceOne(course => course.Id == id, courseIn);
        }

        public void Remove(CourseModel courseIn)
        {
            _courses.DeleteOne(course => course.Id == courseIn.Id);
        }

        public void Remove(string id)
        {
            _courses.DeleteOne(course => course.Id == id);
        }

        public List<StudentModel> GetstudentsByCourse(string id)
        {
            var result = _students.Find(s => s.Courses.Contains(id));

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<StudentModel>();
            }
        }


        // Display all course by name instead of the id.
        //public string StringCourseNames()
        //{
        //    string courseNames = "";
        //    List<CourseModel> allCourses = courseService.GetAllCourses();

        //    var courses = allCourses.Where(c => Courses.Contains(c.Id)).Select(c => c.Name);

        //    courseNames = string.Join(",", courses);

        //    return courseNames;
        //}
    }
}
