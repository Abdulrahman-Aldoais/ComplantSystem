
using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    [Authorize(UserRoles.AdminGeneralFederation)]
    public class AccountGeneralFederationController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AppCompalintsContextDB context;

        public AccountGeneralFederationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            AppCompalintsContextDB context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AddUser()
        {
            var role = _roleManager.Roles.ToString();
            ViewBag.Role = role;

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel userVM)
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

        private async Task LoadAsync(ApplicationUser userVM)
        {
            var userName = await _userManager.GetUserNameAsync(userVM);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(userVM);
            var fullName = userVM.FullName;
            var profilePicture = userVM.ProfilePicture;


            var userData = new ApplicationUser
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
        }

    }
}
