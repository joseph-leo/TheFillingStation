using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheFillingStation.Models;


namespace TheFillingStation.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public IActionResult Index()
        {
            var ev = new Event(new DateTime(2025, 12, 31), "New Year’s Eve Party", "9:00 PM – 12:00 AM", "Ring in the New Year at The Filling Station. Music, drinks, and a midnight countdown.", "Featured");
            var newEv = ev with { Badge = "Hi" };
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Laundromat()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Privacy()
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
