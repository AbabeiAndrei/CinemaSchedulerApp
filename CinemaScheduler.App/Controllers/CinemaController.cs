using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaScheduler.App.Controllers
{
    [AllowAnonymous]
    public class CinemaController : Controller
    {
        public IActionResult Index() => View();
    }
}