using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCourses()
        {
            List<CourseModel> course = new List<CourseModel>();

            course.Add(new CourseModel { Id = 0, Name = "Junior Python Developer", LessonID = 0 });
            course.Add(new CourseModel { Id = 1, Name = "Full Stack Webdeveloper", LessonID = 0 });
            course.Add(new CourseModel { Id = 2, Name = "Fotografie", LessonID = 0 });

            return View(course);
        }
    }
}
