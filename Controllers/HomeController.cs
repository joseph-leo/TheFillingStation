using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheFillingStation.Data;
using TheFillingStation.Models;


namespace TheFillingStation.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
        {
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
        public async Task<IActionResult> Events()
        {
            var eventEntities = await context.Events.ToListAsync();
            List<EventDetailsVm> events = [];
            foreach (var e in eventEntities)
            {
                events.Add(new EventDetailsVm
                {
                    Id =  e.Id,
                    Title = e.Title,
                    EventDate =  e.EventDate,
                    StartTime =  e.StartTime,
                    EndTime =  e.EndTime,
                    Summary =   e.Summary,
                    Badge =   e.Badge,
                });
            }
            return View(events);
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
