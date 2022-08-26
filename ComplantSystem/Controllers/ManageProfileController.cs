using AutoMapper;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.IdentityNumber = model.IdentityNumber;
                    currentUser.FullName = model.FullName;
                    currentUser.PhoneNumber = model.PhoneNumber;
                    currentUser.Governorate.Name = model.Governorates.Name;
                    currentUser.Directorate.Name = model.Directorates.Name;
                    currentUser.SubDirectorate.Name = model.SubDirectorate.Name;


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




        // GET: Users/EditeMyProfile/5
        public async Task<IActionResult> EditeMyProfile(string id)
        {


            string username = User.Identity.Name;

            // Fetch the userprofile
            ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser();
            model.FullName = user.FullName;
            model.PhoneNumber = user.PhoneNumber;
            model.Email = user.Email;

            return View(model);

            //var users = await _userService.GetAllAsync();
            //ViewBag.UserCount = users.Count();
            //var user = await _userService.GetByIdAsync(id);

            //if (user == null)
            //{
            //    return NotFound();
            //}
            //var newUser = new EditUserViewModel
            //{

            //    PhoneNumber = user.PhoneNumber,
            //    IsBlocked = user.IsBlocked,
            //    //userRoles = user.UserRoles,


            //};
            //return View(newUser);
        }


        [HttpPost]

        public async Task<IActionResult> EditeMyProfile(ApplicationUser userprofile)
        {



            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields
                user.FullName = userprofile.FullName;
                user.PhoneNumber = userprofile.PhoneNumber;
                user.DateOfBirth = userprofile.DateOfBirth;

                context.Entry(user).State = EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Profile", "ManageProfile"); // or whatever
            }

            return View(userprofile);


            //var users = await _userService.GetAllAsync();
            //ViewBag.UserCount = users.Count();
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        await _userService.UpdateAsync(id, user);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UserExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View();
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
