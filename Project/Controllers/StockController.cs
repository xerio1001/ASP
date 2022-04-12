using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StockController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult pasStockAan()
        {
            return View();
        }

        public IActionResult overzichtStock()
        {
            return View();
        }

        public IActionResult overzichtLeveranciers()
        {
            return View();
        }

        public IActionResult bestel()
        {
            return View();
        }

        public IActionResult voegProductToe()
        {
            return View();
        }

        public IActionResult voegLeverancierToe()
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