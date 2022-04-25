namespace OpdrachtSchoolVakken.Models
{
    public class StudentModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Courses { get; set; } = new List<string>();

        public Dictionary<string, int> Results { get; set; } = new Dictionary<string, int>();

        private static List<StudentModel> _students = new List<StudentModel>();

        static StudentModel()
        {
            _students.Add(new StudentModel { Id = Guid.NewGuid().ToString(), Name = "Dario", Age = 20, Gender = "Male", PhoneNumber = "0123456789", Courses = {  } });
            _students.Add(new StudentModel { Id = Guid.NewGuid().ToString(), Name = "Jens", Age = 32, Gender = "Male", PhoneNumber = "547849464747", Courses = {  } });
        }

        public List<string> GetCoursesId()
        {
            List<CourseModel> allCourses = CourseModel.GetAllCourses();

            List<string> courseId = allCourses.Select(c => c.Id).ToList();

            return courseId;
        }

        public List<string> GetCoursesForStudent()
        {
            List<CourseModel> allCourses = CourseModel.GetAllCourses();

            List<string> listCourses = allCourses.Where(c => Courses.Contains(c.Id)).Select(c => c.Name).ToList();

            return listCourses;
        }

        public static List<StudentModel> GetAllStudents()
        {
            return _students;
        }

        public static StudentModel GetStudent(string id)
        {
            foreach (StudentModel student in _students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public void SaveStudent()
        {
            
        }

        public static void AddStudent(StudentModel student)
        {
            _students.Add(student);
        }

        public static void DeleteStudent(string id)
        {
            foreach (StudentModel student in _students)
            {
                if(student.Id == id)
                {
                    _students.Remove(student);
                    break;
                }
            }
        }
    }
}
