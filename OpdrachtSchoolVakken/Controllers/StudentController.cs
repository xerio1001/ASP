using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListStudents()
        {
            return View();
        }
    }
}
