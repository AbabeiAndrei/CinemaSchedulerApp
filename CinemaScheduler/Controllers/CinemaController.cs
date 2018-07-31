using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CinemaScheduler.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index() => View(); 

        public IActionResult Login() => View();
    }
}