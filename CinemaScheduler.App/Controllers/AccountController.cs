using System.Threading.Tasks;

using CinemaScheduler.App.Data;
using CinemaScheduler.App.Entities;
using CinemaScheduler.App.Models;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CinemaScheduler.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            
            if (result.IsLockedOut)
                return RedirectToAction("Lockout");

            if (result.Succeeded) 
                return RedirectToAction("Index", "Cinema");

            ModelState.AddModelError(string.Empty, "Username or password is incorect");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var user = new ApplicationUser(model.Username)
            {
                Email = model.Email,
                FullName = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View();
        }
        
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Cinema");
        }
    }
}