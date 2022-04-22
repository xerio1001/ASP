using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListTeachers()
        {
            List<TeacherModel> teacher = new List<TeacherModel>();

            teacher.Add(new TeacherModel { Id = 0, Name = "Bert", Age = 45, Gender = "Male", PhoneNumber = "1234567890", CourseID = 0 });
            teacher.Add(new TeacherModel { Id = 0, Name = "Danny", Age = 40, Gender = "Male", PhoneNumber = "1564644446", CourseID = 1 });
            teacher.Add(new TeacherModel { Id = 0, Name = "Jeff", Age = 45, Gender = "Male", PhoneNumber = "44498746584", CourseID = 2 });

            return View(teacher);
        }
    }
}
