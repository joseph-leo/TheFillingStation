using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheFillingStation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public sealed class EventsController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Create() => View();
    public IActionResult Edit(int id) => View();
    public IActionResult Delete(int id) => View();
}