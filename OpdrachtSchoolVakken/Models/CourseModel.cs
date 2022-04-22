namespace OpdrachtSchoolVakken.Models
{
    public class CourseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string LessonID { get; set; }

        private static List<CourseModel> _course = new List<CourseModel>();

        static CourseModel()
        {
            _course.Add(new CourseModel { Id = Guid.NewGuid().ToString(), Name = "Junior Python Developer", LessonID = "0" });
            _course.Add(new CourseModel { Id = Guid.NewGuid().ToString(), Name = "Full Stack Webdeveloper", LessonID = "0" });
        }

        public static List<CourseModel> GetAllCourses()
        {
            return _course;
        }

        public static CourseModel GetCourse(string id)
        {
            foreach (CourseModel course in _course)
            {
                if (course.Id == id)
                {
                    return course;
                }
            }
            return null;
        }

        public static void EditCourse(CourseModel course)
        {
            foreach (CourseModel courseModel in _course)
            {
                if (courseModel.Id == course.Id)
                {
                    courseModel.Name = course.Name;
                    courseModel.LessonID = course.LessonID;
                }
            }
        }

        public static void AddCourse(CourseModel course)
        {
            _course.Add(course);
        }

        public static void DeleteCourse(string id)
        {
            foreach (CourseModel course in _course)
            {
                if (course.Id == id)
                {
                    _course.Remove(course);
                    break;
                }
            }
        }
    }
}
