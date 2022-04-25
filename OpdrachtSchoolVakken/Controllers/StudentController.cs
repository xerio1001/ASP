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
                student.Courses = collection["Courses"].ToList();

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
            ViewBag.courses = CourseModel.GetAllCourses();
            return View(StudentModel.GetStudent(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                List<string> courseId = new List<string>();

                StudentModel newStudent = StudentModel.GetAllStudents().Where(student => student.Id == id).First();
                newStudent.Name = collection["Name"];
                newStudent.Age = int.Parse(collection["Age"]);
                newStudent.Gender = collection["Gender"];
                newStudent.PhoneNumber = collection["PhoneNumber"];

                var selectedItems = collection.Where(x => x.IsChecked);

                //foreach (var course in CourseModel.GetAllCourses())
                //{
                //    if (collection[course.Id] == "true")
                //    {
                //        courseId.Add(course.Id);
                //    }
                //}
                //newStudent.Courses = courseId;

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
