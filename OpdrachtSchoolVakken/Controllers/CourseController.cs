using OpdrachtSchoolVakken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseService.GetAllCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CourseModel course = new CourseModel();

                course.Name = collection["Name"];

                courseService.Create(course);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(courseService.GetOne(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                CourseModel newCourse = courseService.GetAllCourses().Where(course => course.Id == id).First();
                newCourse.Name = collection["Name"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(string id)
        {
            courseService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
