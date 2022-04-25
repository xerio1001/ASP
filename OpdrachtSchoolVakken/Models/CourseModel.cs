namespace OpdrachtSchoolVakken.Models
{
    public class CourseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        private static List<CourseModel> _course = new List<CourseModel>();

        static CourseModel()
        {
            _course.Add(new CourseModel { Name = "Python" });
            _course.Add(new CourseModel { Name = "C#/.Net" });
            _course.Add(new CourseModel { Name = "HTML5/CSS" });
            _course.Add(new CourseModel { Name = "SQL" });
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
            throw new NotImplementedException();
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
