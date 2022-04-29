using OpdrachtSchoolVakken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OpdrachtSchoolVakken.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;
        private readonly TeacherService teacherService;
        private readonly StudentService studentService;

        public CourseController(CourseService courseService, TeacherService teacherService, StudentService studentService)
        {
            this.courseService = courseService;
            this.teacherService = teacherService;
            this.studentService = studentService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseService.GetAllCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(string id)
        {
            return View(courseService.GetOne(id));
        }

        // GET: CourseController/Create
        public ActionResult Create() 
        { 
            List<TeacherModel> teachers = teacherService.GetAllTeachers();
            SelectList teacherList = new SelectList(teachers, "Id", "Name");
            ViewBag.teachers = teacherList;
        
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
                course.Teacher = collection["Teacher"];

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
            List<TeacherModel> teachers = teacherService.GetAllTeachers();
            SelectList teacherList = new SelectList(teachers, "Id", "Name");
            ViewBag.teachers = teacherList;

            List<StudentModel> students = courseService.GetstudentsByCourse(id);
            ViewBag.students = students;

            return View(courseService.GetOne(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                CourseModel newCourse = courseService.GetOne(id);
                newCourse.Name = collection["Name"];
                newCourse.Teacher = collection["Teacher"];

                courseService.Update(id, newCourse);

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
