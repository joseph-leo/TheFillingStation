using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheFillingStation.Models;

namespace TheFillingStation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public sealed class EventsController : Controller
{
    public IActionResult Index() 
    {
        List<EventViewModel> events = [new EventViewModel(new DateTime(2025, 12, 31), "New Year’s Eve Party", "9:00 PM – 12:00 AM", "Ring in the New Year at The Filling Station. Music, drinks, and a midnight countdown.", "Featured")];
        return View(events); 
    }

    public IActionResult Create() => View();
    public IActionResult Edit(int id) => View();
    public IActionResult Delete(int id) => View();
}