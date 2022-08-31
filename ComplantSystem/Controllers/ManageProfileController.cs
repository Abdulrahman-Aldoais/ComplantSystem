using AutoMapper;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    public class ManageProfileController : Controller
    {


        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICompalintRepository _compalintService;
        private readonly IRegionsRepo _regions;
        private readonly AppCompalintsContextDB context;
        private readonly IMapper mapper;

        public ManageProfileController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ICompalintRepository compalintService,
            IRegionsRepo regions,
            AppCompalintsContextDB context,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _compalintService = compalintService;
            _regions = regions;
            this.context = context;
            this.mapper = mapper;
            _compalintService = compalintService;
        }



        public async Task<IActionResult> Profile(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var model = mapper.Map<UserViewModels>(currentUser);
                return View(model);
            }
            return NotFound();


        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModels model)
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var userId = currentUser.Id;
            var user = await _userService.GetByIdAsync((string)userId);
            if (user == null)
            {
                return NotFound();
            }


            return View(model);
        }



        public async Task<IActionResult> EditMyProfile()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var model = mapper.Map<UserProfileEditVM>(currentUser);

                return View(model);
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> EditMyProfile(UserProfileEditVM model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.IdentityNumber = model.IdentityNumber;
                    currentUser.FullName = model.FullName;
                    currentUser.PhoneNumber = model.PhoneNumber;


                    var result = await _userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {

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





        private bool UserExists(string id)
        {
            return string.IsNullOrEmpty(_userService.GetByIdAsync(id).ToString());
        }



        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _userManager.ChangePasswordAsync(currentUser, changePassword.CurrentPassword, changePassword.NewPassword);
                    if (result.Succeeded)
                    {
                        //TempData["Success"] = stringLocalizer["ChangePasswordMessage"]?.Value;
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Login");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                return NotFound();
            }
            return View("Login", mapper.Map<ChangePasswordViewModel>(currentUser));


        }


        public async Task<IActionResult> ChangePassword()
        {
            return View();

        }




    }
}
