using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoponWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //UserManager-Manage User(Register)
        //SignInManager->Login/Logout
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if(ModelState.IsValid)
            {
                //Create IdentityUser->Copy Data from register
                var user = new IdentityUser()
                {
                    UserName = register.UserName,
                    Email = register.LoginId,
                    PhoneNumber = register.MobileNumber
                };
                //UserManager ->Register
                var result = await userManager.CreateAsync(user, register.Password);
                if(result.Succeeded)
                {
                    //Consider user as login
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //Redirect to Home page
                    return RedirectToAction("Index", "Home");
                }
                //To Handle error
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(register);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if(ModelState.IsValid)
            {
                var result =await signInManager.PasswordSignInAsync(user.LoginId, user.Password, user.RememberMe, false);
                if(result.Succeeded)
                {
                    //based on from where user is redirected to login page,we have to redirect to that page.
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login ID or password");
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
