using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheFillingStation.Controllers;

[Authorize(Roles = "AdminOnly")]
public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}