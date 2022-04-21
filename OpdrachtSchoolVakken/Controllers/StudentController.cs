using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult ListStudents()
        {
            return View(StudentModel.GetAllStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult CreateNew()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew(IFormCollection collection)
        {
            try
            {
                StudentModel student = new StudentModel();

                student.Name = collection["Name"];
                student.Age = int.Parse(collection["Age"]);
                student.Gender = collection["Gender"];
                student.PhoneNumber = collection["Phonenumber"];
                student.CourseID = int.Parse(collection["CourseID"]);

                StudentModel.AddStudent(student);

                return RedirectToAction(nameof(ListStudents));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(string name)
        {   
            StudentModel.DeleteStudent(name);
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string name, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ListStudents));
            }
            catch
            {
                return View();
            }
        }
    }
}
