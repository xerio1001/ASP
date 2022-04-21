using Microsoft.AspNetCore.Mvc;
using OpdrachtSchoolVakken.Models;

namespace OpdrachtSchoolVakken.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListLesson()
        {
            List<LessonModel> lesson = new List<LessonModel>();

            lesson.Add(new LessonModel { Id = 0, Name = "Python 101", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 1, Name = "Datamanagment", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 2, Name = "Troubleshooting", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 3, Name = "HTML5", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 4, Name = "CSS", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 5, Name = "JavaScript", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 6, Name = "Photoshop", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 7, Name = "Lightroom", MaxScore = 100 });
            lesson.Add(new LessonModel { Id = 8, Name = "foto creatie", MaxScore = 100 });

            return View(lesson);
        }
    }
}
