using AutoMapper;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    public class ManageUsersController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICompalintRepository _compalintService;
        private readonly ILocationRepo<Governorate> governorate;
        private readonly AppCompalintsContextDB _context;
        private readonly IRegionsRepo _regions;
        private readonly IMapper mapper;

        public ManageUsersController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ICompalintRepository compalintService,
            ILocationRepo<Governorate> governorate,
            AppCompalintsContextDB context,
            IRegionsRepo regions,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _compalintService = compalintService;
            this.governorate = governorate;
            _context = context;
            _regions = regions;
            this.mapper = mapper;
            _compalintService = compalintService;
        }





        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }




        public async Task<IActionResult> ViewUsers(
         string currentFilter,
         string searchString,
         int? pageNumber)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var result = await _userService.GetAllAsync(currentIdUser);


            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;

            int pageSize = 3;



            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

        }



        public async Task<IActionResult> BeneficiariesAccount()
        {
            var result = await _userService.GetAllBenefAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            return View(result.ToList());

        }




        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync((string)id, u => u.Governorate, d => d.Directorate, n => n.SubDirectorate);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _compalintService.DeleteAsync(id);
            return RedirectToAction(nameof(ViewUsers));
        }

        public async Task<IActionResult> Block()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;


            var result = _userService.GetAllUserBlockedAsync(currentIdUser);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Block(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var result = await _userService.TogelBlockUserAsync(userId);
                if (result.Success)
                {
                    TempData["Succes"] = result.Message;
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
                return RedirectToAction("Index");
            }
            TempData["Error"] = "لم يتم العثور على رقم المستخدم";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Search(InputSearch input)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Search(input.Term);
                return View(result);
            }
            return View();
        }
        public async Task<IActionResult> AccountRestriction()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;
            var result = _userService.GetAllUserBlockedAsync(currentIdUser);



            return View(result.ToList());

        }



        public async Task<IActionResult> UsersCounts()
        {
            var totalUsersCount = await _userService.UserRegistrationCountAsync();
            var month = DateTime.Today.Month;
            var monthUsersCount = await _userService.UserRegistrationCountAsync(month);

            return Json(new { tota = totalUsersCount, month = monthUsersCount });

        }


        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            var model = new AddUserViewModel()
            {

                GovernoratesList = await _context.Governorates.ToListAsync()
            };
            ViewBag.ViewGover = model.GovernoratesList.ToArray();
            return View(model);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            model.GovernoratesList = await _context.Governorates.ToListAsync();
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            var currentId = currentUser.IdentityNumber;

            if (ModelState.IsValid)
            {
                var userIdentity = await _userManager.FindByEmailAsync(model.IdentityNumber);
                if (userIdentity != null)
                {
                    ModelState.AddModelError("Email", "email aoset");
                    model.GovernoratesList = await _context.Governorates.ToListAsync();
                    ViewBag.ViewGover = model.GovernoratesList.ToArray();
                    return View(model);
                }
                if (_userService.returntype == 1)
                {
                    TempData["Error"] = _userService.Error;
                    return View(model);
                }
                else if (_userService.returntype == 2)
                {
                    TempData["Error"] = _userService.Error;
                    return View(model);
                }


                await _userService.AddAsync(model, currentName, currentId);

                return RedirectToAction(nameof(ViewUsers));
            }
            return View(model);
        }


        [AllowAnonymous]

        public async Task<IActionResult> CheckingIdentityNumber(AddUserViewModel model)
        {
            var user = _userManager.FindByEmailAsync(model.IdentityNumber);

            var userr = _context.Users.Where(a => a.IdentityNumber == model.IdentityNumber).FirstOrDefault();
            if (userr == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"  من قبل بهذا الرقم {model.IdentityNumber}  يوجد رقم بطاقة");
            }


        }

        [AllowAnonymous]
        public async Task<IActionResult> CheckingPhoneNumber(AddUserViewModel model)
        {


            if (model.PhoneNumber.Length == 9)
            {
                return Json(true);
            }

            else
            {
                return Json($"  موجود من قبل {model.IdentityNumber}  رقم الهاتف هذا ");
            }


        }


        [HttpGet]
        public async Task<IActionResult> GetDirectorateies(int id)
        {
            List<Directorate> directorate = new List<Directorate>();
            directorate = await _context.Directorates.Where(m => m.GovernorateId == id).ToListAsync();
            return Json(new SelectList(directorate, "Id", "Name"));
        }


        public async Task<IActionResult> GetSubDirectorat(int id)
        {
            List<SubDirectorate> subdirectorate = new List<SubDirectorate>();
            subdirectorate = await _context.SubDirectorates.Where(m => m.DirectorateId == id).ToListAsync();
            return Json(new SelectList(subdirectorate, "Id", "Name"));
        }






        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.UserCount = users.Count();

            var user = await _userService.GetByIdAsync((string)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            var users = await _userService.GetAllAsync();
            ViewBag.UserCount = users.Count();
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var newUser = new EditUserViewModel
            {

                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                IsBlocked = user.IsBlocked,
                DateOfBirth = user.DateOfBirth,


                //userRoles = user.UserRoles,


            };
            return View(newUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel user)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.UserCount = users.Count();
            if (!ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateAsync(id, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ViewUsers));
            }
            return View();
        }


        private bool UserExists(string id)
        {
            return string.IsNullOrEmpty(_userService.GetByIdAsync(id).ToString());
        }


        public async Task<IActionResult> ChaingeStatusAsync(string id, bool IsBlocked)
        {
            await _userService.ChaingeStatusAsync(id, IsBlocked);
            return RedirectToAction("ViewUsers");
        }




    }
}
