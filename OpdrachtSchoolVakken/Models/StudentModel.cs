using OpdrachtSchoolVakken.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace OpdrachtSchoolVakken.Models
{
    [BsonIgnoreExtraElements]
    public class StudentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [DisplayName("Age")]
        [BsonElement("age")]
        public int Age { get; set; }

        [DisplayName("Gender")]
        [BsonElement("gender")]
        public string Gender { get; set; }

        [DisplayName("Phonenumber")]
        [BsonElement("phonenumber")]
        public string PhoneNumber { get; set; }

        [DisplayName("Courses")]
        [BsonElement("courses")]
        public List<string> Courses { get; set; } = new();

        [DisplayName("Results")]
        [BsonElement("results")]
        public Dictionary<string, string> Results { get; set; } = new Dictionary<string, string>();

        //private static List<StudentModel> _students = new List<StudentModel>();

        ////static StudentModel()
        ////{
        ////    _students.Add(new StudentModel { Name = "Dario", Age = 20, Gender = "Male", PhoneNumber = "0123456789" });
        ////    _students.Add(new StudentModel { Name = "Jens", Age = 32, Gender = "Male", PhoneNumber = "547849464747" });
        ////}

        //public List<string> GetCoursesId()
        //{
        //    List<CourseModel> allCourses = CourseModel.GetAllCourses();

        //    List<string> courseId = allCourses.Select(c => c.Id).ToList();

        //    return courseId;
        //}

        //public List<string> GetCoursesForStudent()
        //{
        //    List<CourseModel> allCourses = CourseModel.GetAllCourses();

        //    List<string> listCourses = allCourses.Where(c => Courses.Contains(c.Id)).Select(c => c.Name).ToList();

        //    return listCourses;
        //}

        //public static List<StudentModel> GetAllStudents()
        //{
        //    return _students;
        //}

        //public static StudentModel GetStudent(string id)
        //{
        //    foreach (StudentModel student in _students)
        //    {
        //        if (student.Id == id)
        //        {
        //            return student;
        //        }
        //    }
        //    return null;
        //}

        //public void SaveStudent()
        //{

        //}

        //public static void AddStudent(StudentModel student)
        //{
        //    _students.Add(student);
        //}

        //public static void DeleteStudent(string id)
        //{
        //    foreach (StudentModel student in _students)
        //    {
        //        if(student.Id == id)
        //        {
        //            _students.Remove(student);
        //            break;
        //        }
        //    }
        //}
    }
}
