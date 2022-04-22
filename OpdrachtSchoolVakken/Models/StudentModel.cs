namespace OpdrachtSchoolVakken.Models
{
    public class StudentModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public int CourseID { get; set; }

        private static List<StudentModel> _students = new List<StudentModel>();

        static StudentModel()
        {
            _students.Add(new StudentModel { Id = Guid.NewGuid().ToString(), Name = "Dario", Age = 20, Gender = "Male", PhoneNumber = "0123456789", CourseID = 0 });
            _students.Add(new StudentModel { Id = Guid.NewGuid().ToString(), Name = "Jens", Age = 32, Gender = "Male", PhoneNumber = "547849464747", CourseID = 0 });
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

        public static void EditStudent(StudentModel student)
        {
            foreach (StudentModel studentModel in _students)
            {
                if(studentModel.Id == student.Id)
                {
                    studentModel.Name = student.Name;
                    studentModel.Age = student.Age;
                    studentModel.Gender = student.Gender;
                    studentModel.PhoneNumber = student.PhoneNumber;
                    studentModel.CourseID = student.CourseID;
                }
            }
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
