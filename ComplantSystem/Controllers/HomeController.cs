using ComplantSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
            private readonly UserManager<ApplicationUser> userManager;

            public HomeController(UserManager<ApplicationUser> userManager)
            {
                this.userManager = userManager;
            }
            [Authorize(Roles = "User")]
            public IActionResult Index()
            {
                string userName = userManager.GetUserName(User);
                return View("Index", userName);
            }
            public IActionResult Logins()
        {
            return View();
        }
    }
}
