using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace OpdrachtSchoolVakken.Models
{
    [BsonIgnoreExtraElements]
    public class CourseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [DisplayName("Name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [DisplayName("Teacher")]
        [BsonElement("teacher")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Teacher { get; set; }

        //private static List<CourseModel> _course = new List<CourseModel>();

        //static CourseModel()
        //{
        //    _course.Add(new CourseModel { Name = "Python" });
        //    _course.Add(new CourseModel { Name = "C#/.Net" });
        //    _course.Add(new CourseModel { Name = "HTML5/CSS" });
        //    _course.Add(new CourseModel { Name = "SQL" });
        //}

        //public static List<CourseModel> GetAllCourses()
        //{
        //    return _course;
        //}

        //public static CourseModel GetCourse(string id)
        //{
        //    foreach (CourseModel course in _course)
        //    {
        //        if (course.Id == id)
        //        {
        //            return course;
        //        }
        //    }
        //    return null;
        //}

        //public static void EditCourse(CourseModel course)
        //{
        //    throw new NotImplementedException();
        //}

        //public static void AddCourse(CourseModel course)
        //{
        //    _course.Add(course);
        //}

        //public static void DeleteCourse(string id)
        //{
        //    foreach (CourseModel course in _course)
        //    {
        //        if (course.Id == id)
        //        {
        //            _course.Remove(course);
        //            break;
        //        }
        //    }
        //}
    }
}
