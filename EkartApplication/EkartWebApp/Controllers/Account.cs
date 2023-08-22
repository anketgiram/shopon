using EkartEF.Models;
using EkartWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EkartWebApp.Controllers
{
    public class Account : Controller
    {
        private readonly SignInManager<Staff> signInManager;
        private readonly UserManager<Staff> userManager;
        public Account(UserManager<Staff> userManager, SignInManager<Staff> signInManager)
        {
            // usermanager is used for create user related data
            //signmanager is used for checking wether user is login or not
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            // here we are using SigninManager bcoz we are checking for signin or signout
            // Modelstate is used for enter data is valied or not
            if(ModelState.IsValid)
            {
                //for checking wether user is user is login or not
                var result = await signInManager.PasswordSignInAsync(login.EmailId, login.Password, login.RememberMe, false);

                //if user enter username and password properly
                if(result.Succeeded)
                {
                    //if id and password is correct then user hase to go Order Page
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("Index", "Order");
                }

                //and if user not enter username and password correctly then throw error
                ModelState.AddModelError("", "Invalied Email Id or Password");

            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Register(RegisterVM register)
        {
            //here we use UserManager bcoz we are cretaing user
            //check wether register user has valied data or not
            if(ModelState.IsValid)
            {
                //1 create staff object
                var user = new Staff()
                {
                    City = register.City,
                    State = register.State,
                    Email = register.EmailId,
                    //here our EmailId and username both are same bcoz of that "register.EmailId" we use this as value fro register
                    UserName = register.EmailId
                };

                //2 Register User ==> create the user
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    //2.1 Consider User has logged in
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //if id and password is correct then user hase to go Order Page
                   // return RedirectToAction("Index", "Home");
                    return RedirectToAction("Index", "Order");
                }

                //3 push all error 
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", "error.Description");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //to clear the session
            HttpContext.Session.Clear();
            //for log out the particular user
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
