namespace OpdrachtSchoolVakken.Models
{
    public class TeacherModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public List<string> Courses { get; set; } = new();

        private static List<TeacherModel> _teachers = new List<TeacherModel>();

        static TeacherModel()
        {
            _teachers.Add(new TeacherModel { Name = "Bert", Age = 45, Gender = "Male" });
            _teachers.Add(new TeacherModel { Name = "Danny", Age = 40, Gender = "Male" });
            _teachers.Add(new TeacherModel { Name = "Sara", Age = 25, Gender = "Female" });
        }

        public List<string> GetCoursesId()
        {
            List<CourseModel> allCourses = CourseModel.GetAllCourses();

            List<string> courseId = allCourses.Select(c => c.Id).ToList();

            return courseId;
        }

        //public List<string> GetCoursesForStudent()
        //{
        //    List<CourseModel> allCourses = CourseModel.GetAllCourses();

        //    List<string> listCourses = allCourses.Where(c => Courses.Contains(c.Id)).Select(c => c.Name).ToList();

        //    return listCourses;
        //}

        public static List<TeacherModel> GetAllTeachers()
        {
            return _teachers;
        }

        public static TeacherModel GetTeacher(string id)
        {
            foreach (TeacherModel teacher in _teachers)
            {
                if (teacher.Id == id)
                {
                    return teacher;
                }
            }
            return null;
        }

        public void SaveTeacher()
        {

        }

        public static void AddTeacher(TeacherModel teacher)
        {
            _teachers.Add(teacher);
        }

        public static void DeleteTeacher(string id)
        {
            foreach (TeacherModel teacher in _teachers)
            {
                if (teacher.Id == id)
                {
                    _teachers.Remove(teacher);
                    break;
                }
            }
        }
    }
}
