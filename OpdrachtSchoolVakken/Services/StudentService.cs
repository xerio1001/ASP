﻿using MongoDB.Driver;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<StudentModel> _students;

        public StudentService()
        {
            MongoClient client = new MongoClient("mongodb+srv://m001-student:m001-mongodb-basics@sandbox.o2oak.mongodb.net/Sandbox?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("school-data");
            _students = database.GetCollection<StudentModel>("students");
        }

        public List<StudentModel> GetAllStudents()
        {
            return _students.Find(student => true).ToList();
        }

        public StudentModel GetOne(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public StudentModel Create(StudentModel student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, StudentModel studentIn)
        {
            _students.ReplaceOne(student => student.Id == id, studentIn);
        }

        public void Remove(StudentModel studentIn)
        {
            _students.DeleteOne(student => student.Id == studentIn.Id);
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public List<string> GetCoursesForStudent()
        {
            List<CourseModel> allCourses = courseService.GetAllCourses();

            List<string> listCourses = allCourses.Where(c => Courses.Contains(c.Id)).Select(c => c.Name).ToList();

            return listCourses;
        }
    }
}
