﻿using ComplantSystem.Data.Base;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem

{

    [Authorize(Roles = "AdminGeneralFederation")]
    public class GeneralFederationController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;
        private readonly ICompalintRepository _compReop;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISolveCompalintService solveCompalintService;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public GeneralFederationController(
            ILocationRepo<Governorate> governorate,
            ILocationRepo<Directorate> directorate,
            ILocationRepo<SubDirectorate> subDirectorate,
            ILocationRepo<Village> village,
            ICategoryService service,
            ICompalintRepository compReop,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            ISolveCompalintService solveCompalintService,

            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {
            this.governorate = governorate;
            this.directorate = directorate;
            this.subDirectorate = subDirectorate;
            this.village = village;
            _compReop = compReop;
            _userService = userService;
            _userManager = userManager;
            this.solveCompalintService = solveCompalintService;
            _service = service;
            _context = context;
            _env = env;

        }


        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        public async Task<IActionResult> UpCompalint(string id, UploadsComplainte complainte)
        {

            var upComp = await _compReop.FindAsync(id);
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
            if (dbComp != null)
            {

                dbComp.Id = complainte.Id;
                dbComp.StagesComplaintId = dbComp.StagesComplaintId + 1;


                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllComplaints));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSolutions(ProvideSolutionsVM model, string id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var role = currentUser.RoleId;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var solution = new Compalints_Solution()
                {
                    UserId = subuser.Id,
                    SolutionProvName = subuser.FullName,
                    UploadsComplainteId = model.AddSolution.UploadsComplainteId,
                    SolutionProvIdentity = subuser.IdentityNumber,
                    ContentSolution = model.AddSolution.ContentSolution,
                    DateSolution = DateTime.Now,
                    //status = model.compalint.StatusCompalintId == 2,
                    Role = role.ToString(),

                };

                _context.Compalints_Solutions.Add(solution);
                await _context.SaveChangesAsync();

                //var comp = await _context.UploadsComplainte.Where(a => a.Id == id).FirstOrDefaultAsync();

                //var returnCompalint = new UploadsComplainte()
                //{
                //    StagesComplaintId = 2,

                //};

                //_context.UploadsComplaintes.Add(returnCompalint);
                //await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return NotFound();

        }



        public async Task<IActionResult> ReportManagement()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var allComp = await _compReop.GetAllAsync(h => h.Governorate);
            var result = await _userService.GetAllAsync(h => h.Governorate);
            var compSolv = allComp.Where(r => r.StatusCompalintId == 2);

            int totalcompSolv = compSolv.Count();
            int totalUsers = result.Count();
            int totalComp = allComp.Count();

            ViewBag.totalcompSolv = totalcompSolv;
            ViewBag.totalUsers = totalUsers;
            ViewBag.totalComp = totalComp;
            return View();
        }

        public async Task<IActionResult> AllCategoriesCommunications()
        {

            return View();
        }

        public async Task<IActionResult> AllCategoriesComplaints()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCompAsync();

            return View(allCategoriesComplaints);
        }

        public async Task<IActionResult> AllComplaints()
        {
            var allComp = _compReop.GetAll();
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }



        public IActionResult AllCirculars()
        {
            return View();
        }

        public IActionResult AddCirculars()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([Bind("Type,UsersNameAddType")] TypeComplaint typeComplaint)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            TypeComplaint type = new TypeComplaint
            {
                Type = typeComplaint.Type,
                UsersNameAddType = currentName,
                UserId = currentUser.Id,

            };

            if (!ModelState.IsValid)
            {
                return View(type);
            }
            await _context.TypeComplaints.AddAsync(type);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCategoriesComplaints));

        }



        [HttpGet]
        public async Task<IActionResult> AddCategoryComm()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryComm([Bind("Type,UsersNameAddType")] TypeComplaint typeComplaint)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            TypeComplaint type = new TypeComplaint
            {
                Type = typeComplaint.Type,
                UsersNameAddType = currentName,
                UserId = currentUser.Id,

            };

            if (!ModelState.IsValid)
            {
                return View(type);
            }
            await _context.TypeComplaints.AddAsync(type);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCategoriesComplaints));

        }

        //Get: Category/Edit/1
        public async Task<IActionResult> EditCategoryComplaint(string id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null) return View("Empty");
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoryComplaint(string id, [Bind("Id,Type,UsersNameAddType")] TypeComplaint typeComplaint)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            TypeComplaint type = new TypeComplaint
            {
                Type = typeComplaint.Type,
                UsersNameAddType = currentName,
                UserId = currentUser.Id,

            };

            if (!ModelState.IsValid)
            {
                return View(type);
            }
            await _service.UpdateAsync(id, type);
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }
        //Get: Category/Delete/1
        public async Task<IActionResult> DeleteCategoryComplainty(string id)
        {
            var selectedCategory = await _compReop.GetByIdAsync(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }


            return View(selectedCategory);

        }

        [HttpPost]
        [ActionName("DeleteCategoryComplainty")]
        public async Task<IActionResult> DeleteConfirmedCategoryComplaint(string id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }


        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            //var ComplantList = await _context.UploadsComplainte.Include(a => a.Governorates).Include(a => a.Directorates).Include(a => a.SubDirectorates).Include(a => a.Villages).Include(a => a.TypeComplaint).Where(m => m.Id == id).FirstOrDefaultAsync();

            //var ComplantList = await _context.UploadsComplainte.Include(a => a.Governorates).Include(a => a.Directorates).Include(a => a.SubDirectorates).Include(a => a.Villages).Include(a => a.TypeComplaint).Where(m => m.Id == id).FirstOrDefaultAsync();
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,


            };
            ProvideSolutionsVM MV = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                AddSolution = addsoiationView
            };
            return View(MV);
        }





        public async Task<IActionResult> DetailsCategoriesComplaints(string id)
        {
            var categorieDetails = await _service.GetByIdAsync(id);
            if (categorieDetails == null)
            {
                return View("Empty");

            }
            return View(categorieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await _compReop.FindAsync(id);
            if (selectedFile == null)
            {
                return NotFound();
            }

            //await _compService.IncreamentDownloadCount(id);

            var path = "~/Uploads/" + selectedFile.FileName;
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");
            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        }


    }
}
