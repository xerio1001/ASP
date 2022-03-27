using Microsoft.AspNetCore.Mvc;
using MyMVCApplication.Models;
using System.Diagnostics;

namespace MyMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MarkWithAK()
        {
            return View();
        }

        public IActionResult Sickmode()
        {
            return View();
        }
        public IActionResult Rooler()
        {
            return View();
        }

        public IActionResult BrennanHeart()
        {
            return View();
        }

        public IActionResult Coone()
        {
            return View();
        }

        public IActionResult Mandy()
        {
            return View();
        }

        public IActionResult PaulElstak()
        {
            return View();
        }

        public IActionResult RanD()
        {
            return View();
        }

        public IActionResult RadicalRedemption()
        {
            return View();
        }

        public IActionResult Sefa()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}