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
        public ActionResult Details(string id)
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
        public ActionResult Edit(string id)
        {

            return View(StudentModel.GetStudent(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                StudentModel student = new StudentModel();

                student.Id = id;
                student.Name = collection["Name"];
                student.Age = int.Parse(collection["Age"]);
                student.Gender = collection["Gender"];
                student.PhoneNumber = collection["Phonenumber"];
                student.CourseID = int.Parse(collection["CourseID"]);

                StudentModel.EditStudent(student);

                return RedirectToAction(nameof(ListStudents));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(string id)
        {   
            StudentModel.DeleteStudent(id);
            return RedirectToAction(nameof(ListStudents));
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
