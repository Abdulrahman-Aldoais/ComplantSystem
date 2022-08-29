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
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICompalintRepository _compalintService;
        private readonly IRegionsRepo _regions;
        private readonly IMapper mapper;

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ICompalintRepository compalintService,
            IRegionsRepo regions,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _compalintService = compalintService;
            _regions = regions;
            this.mapper = mapper;
            _compalintService = compalintService;
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
            return View(new LoginViewModel());
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel signinentity, Userdb sessin, string ReturnUrl)
        //{
        //    string message = "";

        //    using (var context = new ApplicantDataEntities())
        //    {
        //        var umail = context.Userdbs.Where(x => x.u_Email == signinentity.u_Email).FirstOrDefault();

        //        if (umail != null)
        //        {
        //            if (string.Compare(PassHash.Hash(signinentity.u_Password), umail.u_Password) == 0)
        //            {
        //                int timeout = signinentity.Rememberme ? 52600 : 20; // 525600 min=1 year
        //                var ticket = new FormsAuthenticationTicket(signinentity.u_Email, signinentity.Rememberme, timeout);
        //                string encrypted = FormsAuthentication.Encrypt(ticket);
        //                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        //                cookie.Expires = DateTime.Now.AddMinutes(timeout);
        //                cookie.HttpOnly = true;
        //                Response.Cookies.Add(cookie);

        //                if (Url.IsLocalUrl(ReturnUrl))
        //                {
        //                    return Redirect(ReturnUrl);
        //                }
        //                else
        //                {
        //                    TempData["UserProfileData"] = umail;
        //                    return RedirectToAction("Index", "Dashboard");
        //                }
        //            }
        //            else
        //            {
        //                message = "Invalid credentials";
        //            }
        //        }
        //        else
        //        {
        //            message = "User with this email not exists";
        //        }
        //        ViewBag.Message = message;
        //        return View();
        //    }
        //}




        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            TempData["Error"] = null;
            if (!ModelState.IsValid)
            {
                _ = loginVM.IdentityNumber;
                var user = await _userManager.FindByEmailAsync(loginVM.IdentityNumber);
                if (user != null)
                {
                    _ = user.UserName;
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        if (await _userManager.IsEmailConfirmedAsync(user))
                        {
                            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);
                            if (result.Succeeded)
                            {
                                if (User.IsInRole(UserRoles.AdminGeneralFederation))
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
                                    return RedirectToAction("Index", "DirManageComplaints");

                                }
                                else if (User.IsInRole(UserRoles.AdminSubDirectorate))
                                {
                                    return RedirectToAction("Index", "SubManageComplaints");

                                }
                            }

                        }
                        else
                        {
                            TempData["Error"] = "الرجاء تنشيط الحساب من قبل المسؤول ";
                            return View(loginVM);

                        }

                    }
                    TempData["Error"] = "خطا في كلمة السر او الايميل ";

                    return View(loginVM);
                }
                TempData["Error"] = "خطا في كلمة السر او الايميل ";


                return View(loginVM);
            }
            return View();

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

