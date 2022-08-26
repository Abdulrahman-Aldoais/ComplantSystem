using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem
{

    [Authorize(Roles = UserRoles.AdminGovernorate)]
    public class AccountGeneralFederationController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public AccountGeneralFederationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public IActionResult Index()
        {


            return View();
        }





        public IActionResult AddUser()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AdminUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FullName = userVM.FullName,

                    UserName = userVM.IdentityNumber,
                    IdentityNumber = userVM.IdentityNumber,
                    Email = userVM.IdentityNumber,
                    PhoneNumber = userVM.PhoneNumber,
                    GovernorateId = userVM.GovernorateId,
                    CreatedDate = userVM.CreatedDate,
                    SocietyId = userVM.SocietyId,
                    ProfilePicture = userVM.ProfilePicture,


                };
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);
                    return RedirectToAction("Index", "AllUsers");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(userVM);

        }

    }
}
