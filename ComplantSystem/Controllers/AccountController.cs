using AutoMapper;
using ComplantSystem.Const;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ICompalintRepository compalintService,
            IRegionsRepo regions,

            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }




        [HttpGet]
        public IActionResult AddUser()
        {
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
                    Email = userVM.IdentityNumber,
                    PhoneNumber = userVM.PhoneNumber,
                    GovernorateId = userVM.GovernorateId,
                    IsBlocked = userVM.IsBlocked,
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
                    ModelState.AddModelError("تعذر انشاء الحساب ", error.Description);
                }

            }
            return View(userVM);

        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            TempData["Error"] = null;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
                if (result.Succeeded)
                {
                    _ = model.Email;
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }
                        else if (User.IsInRole(UserRoles.AdminGeneralFederation))
                        {
                            return RedirectToAction("Index", "GeneralFederation");

                        }
                        else if (User.IsInRole(UserRoles.Beneficiarie))
                        {
                            return RedirectToAction("Index", "Beneficiarie");

                        }
                        else if (User.IsInRole(UserRoles.AdminGovernorate))
                        {
                            return RedirectToAction("Index", "GovManageComplaints");

                        }
                        else if (User.IsInRole(UserRoles.AdminDirectorate))
                        {
                            return RedirectToAction("Report", "DirManageComplaints");

                        }
                        else if (User.IsInRole(UserRoles.AdminSubDirectorate))
                        {
                            return RedirectToAction("Index", "SubManageComplaints");

                        }

                    }
                    else
                    {
                        TempData["Error"] = " حسابك موقف!  الرجاء تنشيط الحساب من قبل المسؤول";
                        return View(model);

                    }


                }
                TempData["Error"] = " تاكد من صحة كتابة رقم البطاقة او كلمة المرور";
                return View(model);

            }
            return View(model);
        }




        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }





        public async Task<IActionResult> Edit()
        {



            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var model = new EditUserViewModel
                {
                    FullName = currentUser.FullName,
                    DateOfBirth = currentUser.DateOfBirth,
                    PhoneNumber = currentUser.PhoneNumber,
                    CreatedDate = System.DateTime.Now,

                };
                return View(model);
            }
            return View("Empty");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.FullName = model.FullName;

                    var result = await _userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {
                        //TempData["Success"] = stringLocalizer["SuccessMessage"]?.Value;
                        return RedirectToAction("Profile");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return View("Empty");
                }
            }
            return View(model);
        }




    }

}

