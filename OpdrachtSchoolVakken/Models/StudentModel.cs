namespace OpdrachtSchoolVakken.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public int CourseID { get; set; }

        private static List<StudentModel> _students = new List<StudentModel>();

        static StudentModel()
        {
            _students.Add(new StudentModel { Name = "Dario", Age = 20, Gender = "Male", PhoneNumber = "0123456789", CourseID = 0 });
            _students.Add(new StudentModel { Name = "Jens", Age = 32, Gender = "Male", PhoneNumber = "547849464747", CourseID = 0 });
        }

        public static List<StudentModel> GetAllStudents()
        {
            return _students;
        }

        public static void AddStudent(StudentModel student)
        {
            _students.Add(student);
        }

        public static void DeleteStudent(StudentModel student)
        {
            _students.Remove(student);
        }
    }
}
