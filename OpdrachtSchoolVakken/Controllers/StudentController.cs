﻿
using OpdrachtSchoolVakken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService studentService;
        private readonly CourseService courseService;
        private readonly TeacherService teacherService;

        public StudentController(StudentService studentService, CourseService courseService, TeacherService teacherService)
        {
            this.studentService = studentService;
            this.courseService = courseService;
            this.teacherService = teacherService;
        }

        // GET: StudentController
        public ActionResult ListStudents()
        {
            return View(studentService.GetAllStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(string id)
        { 
            var student = studentService.GetOne(id);

            List<string> courseNames = studentService.GetCoursesForStudent(id);
            ViewBag.displayCourseNames = courseNames;

            List<string> coursekeys = student.Results.Keys.ToList();

            List<CourseModel> coursesNames = courseService.GetMultiple(coursekeys);
            ViewBag.displayResultNames = coursesNames;

            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult CreateNew()
        {
            List<CourseModel> courses = courseService.GetAllCourses();
            MultiSelectList courseList = new MultiSelectList(courses, "Id", "Name");
            ViewBag.courses = courseList;
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

                List<string> courseList = collection["Courses"].ToList();

                foreach(string courseId in courseList)
                {
                    student.Results.Add(courseId, null);
                }

                studentService.Create(student);

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
            List<CourseModel> courses = courseService.GetAllCourses();
            MultiSelectList courseList = new MultiSelectList(courses, "Id", "Name");

            ViewBag.courses = courseList;
            return View(studentService.GetOne(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                StudentModel newStudent = studentService.GetOne(id);
                newStudent.Name = collection["Name"];
                newStudent.Age = int.Parse(collection["Age"]);
                newStudent.Gender = collection["Gender"];
                newStudent.PhoneNumber = collection["PhoneNumber"];
                newStudent.Courses = collection["Courses"].ToList();

                studentService.UpdateResults(newStudent);

                studentService.Update(id, newStudent);

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
            studentService.Remove(id);
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
