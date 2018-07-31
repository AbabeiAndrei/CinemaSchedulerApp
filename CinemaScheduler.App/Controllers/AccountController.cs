using System.Threading.Tasks;

using CinemaScheduler.App.Data;
using CinemaScheduler.App.Models;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CinemaScheduler.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        [AllowAnonymous]
        public IActionResult Login()
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

            ModelState.AddModelError(ModelErrorKeys.IncorectUserOrPass, "Username or password is incorect");
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