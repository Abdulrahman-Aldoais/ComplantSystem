using ComplantSystem.Data.Base;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models;
using ComplantSystem.Service;
using ComplantSystem.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem

{

    [Authorize(Roles = "AdminGeneralFederation")]
    public class GeneralFederationController : Controller
    {

        private readonly ICompalintRepository _compReop;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public GeneralFederationController(

            ICategoryService service,
            ICompalintRepository compReop,
            IUserService userService,
            UserManager<ApplicationUser> userManager,

            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {

            _compReop = compReop;
            _userService = userService;
            _userManager = userManager;
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


            //***********************************//

            List<ApplicationUser> applicationUsers = await _context.Users.Include(x => x.Governorate).ToListAsync();
            List<ApplicationUser> UsersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();

            //Totalcountuser
            int TotalCount = applicationUsers.Count();

            ViewBag.TotalCount = TotalCount;

            //total Govermentuser
            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new gtsg
            {
                Name = g.First().Governorate.Name,
                TotalCount = g.Count().ToString(),
                nr = (g.Count() * 100) / TotalCount


            }).ToList();


            // show Name Role Rether Than Id
            var Roles = _context.Roles.ToList();
            var x = from r in Globals.RolesLists
                    join u in UsersRoles
                    on r.Id equals u.RoleId
                    select new ApplicationUser
                    {
                        RoleName = r.Name,
                        UserRoles = u.UserRoles
                    };

            //total Users By Role
            ViewBag.totalRoles = x.GroupBy(j => j.RoleName).Select(g => new gtus
            {
                RoleName = g.First().RoleName,
                TotalCount = g.Count().ToString(),
                nu = (g.Count() * 100) / TotalCount


            }).ToList();


            List<gtus> gtus = new List<gtus>();
            gtus = ViewBag.totalRoles;

            List<gtsg> gtsg = new List<gtsg>();
            gtsg = ViewBag.totalGovermentuser;


            List<UploadsComplainte> compalints = await _context.UploadsComplaintes.Include(r => r.TypeComplaint).ToListAsync();

            int totalcomplant = compalints.Count();
            ViewBag.comtot = totalcomplant;

            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new Type
            {
                Name = g.First().TypeComplaint.Type,
                TotalCount = g.Count(),
                mm = (g.Count() * 100) / totalcomplant
            }).ToList();
            return View();
        }

        public class gtsg
        {
            public string Name { get; set; }

            public string TotalCount { get; set; }
            public double nr { get; set; }

        }

        public class gtus
        {
            public string RoleName { get; set; }

            public string TotalCount { get; set; }
            public double nu { get; set; }

        }

        public class Type
        {
            public string Name { get; set; }
            public double TotalCount { get; set; }
            public double mm { get; set; }


        }


        public async Task<IActionResult> AllComplaints()
        {
            var allComp = _compReop.GetAll();
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> RejectedComplaints()
        {
            var allComp = _compReop.GetAll();
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> SolutionComplaints()
        {
            var allComp = _compReop.GetAll();
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
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



        public async Task<IActionResult> ChaingStatusComp(string id)
        {

            var upComp = await _compReop.FindAsync(id);
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
            if (dbComp != null)
            {
                dbComp.StatusCompalintId = 2;

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
                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
                string userRole = role.Value;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var idComp = model.AddSolution.UploadsComplainteId;
                var solution = new Compalints_Solution()
                {
                    UserId = subuser.Id,
                    SolutionProvName = subuser.FullName,
                    UploadsComplainteId = model.AddSolution.UploadsComplainteId,
                    SolutionProvIdentity = subuser.IdentityNumber,
                    ContentSolution = model.AddSolution.ContentSolution,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.Compalints_Solutions.Add(solution);
                await _context.SaveChangesAsync();


                var upComp = await _compReop.FindAsync(idComp);
                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                if (dbComp != null)
                {
                    dbComp.StatusCompalintId = 2;
                    dbComp.StagesComplaintId = 4;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllComplaints));

            }

            return NotFound();

        }
        public async Task<IActionResult> AllCategoriesCommunications()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCommAsync();

            return View(allCategoriesComplaints);
        }
        [HttpGet]
        public async Task<IActionResult> AddCategoryComm()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryComm([Bind("Type,UsersNameAddType")] TypeCommunication typecomm)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            TypeCommunication type = new TypeCommunication
            {
                Type = typecomm.Type,
                UsersNameAddType = currentName,
                UserId = currentUser.Id,

            };

            if (!ModelState.IsValid)
            {
                return View(type);
            }
            await _context.TypeCommunications.AddAsync(type);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCategoriesComplaints));

        }


        public async Task<IActionResult> AllCategoriesComplaints()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCompAsync();

            return View(allCategoriesComplaints);
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
        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }
        public async Task<IActionResult> ViewCompalintSolutionDetails(string id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }
        public async Task<IActionResult> ViewCompalintRejectedDetails(string id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }

        public async Task<IActionResult> DetailsCategoriesComplaints(string id)
        {

            var type = await _service.GetByIdAsync((string)id);
            if (type == null)
            {
                return NotFound();
            }

            return View(type);
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


        public async Task<IActionResult> AllCommunication()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var UserId = currentUser.Id;
            var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues();

            ViewBag.TypeCommunication = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Name");

            var result = _context.UsersCommunications
            .OrderByDescending(d => d.CreateDate)
            .Include(s => s.User)
            .Include(s => s.TypeCommunication)
            .Include(g => g.Governorate)
            .Include(d => d.Directorate)
            .Include(su => su.SubDirectorate);


            //List<ApplicationUser> meeting = _context.Users.Where(m => m.Id == ).ToList<ApplicationUser>();




            int totalCompalints = result.Count();

            ViewBag.totalCompalints = totalCompalints;

            return View(result.ToList());
        }

        public async Task<IActionResult> DetailsCategoriesComplaint(string id)
        {

            var type = await _service.GetByIdAsync((string)id);
            if (type == null)
            {
                return NotFound();
            }

            return View(type);
        }



        //Get: Category/Delete/1
        [HttpPost]
        public async Task<IActionResult> DeleteCategoryComplainty(string id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");

            await _service.DeleteAsync(id);


            return RedirectToAction(nameof(AllCategoriesComplaints));

        }
        //[HttpPost]
        //[ActionName("DeleteCategoryComplainty")]
        //public async Task<IActionResult> DeleteConfirmedCategoryComplaint(string id)
        //{
        //    try
        //    {
        //        var actorDetails = await _service.GetByIdAsync(id);
        //        if (actorDetails == null) return View("Empty");

        //        await _compReop.DeleteAsync(id);
        //    }
        //    catch
        //    {

        //    }
        //    return RedirectToAction(nameof(AllCategoriesComplaints));
        //}
        //Get: Category/Delete/1

        public async Task<IActionResult> DetailsCategoriesComm(string id)
        {

            var type = await _service.GetCommunicationByIdAsync((string)id);
            if (type == null)
            {
                return NotFound();
            }

            return View(type);
        }
        public async Task<IActionResult> DeleteCategoryComm(string id)
        {
            var selectedCategory = await _service.GetCommunicationByIdAsync(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }


            return View(selectedCategory);

        }
        [ActionName("DeleteCategoryComm")]
        public async Task<IActionResult> DeleteConfirmedCategoryComm(string id)
        {
            try
            {
                var actorDetails = await _service.GetCommunicationByIdAsync(id);
                if (actorDetails == null) return View("Empty");

                await _service.DeleteAsync(id);
            }
            catch
            {

            }
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }
        //Get: Category/Edit/1
        public async Task<IActionResult> EditCategoryComm(string id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null) return View("Empty");
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoryComm(string id, [Bind("Id,Type,UsersNameAddType")] TypeComplaint typeComplaint)
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


        public IActionResult AllCirculars()
        {
            return View();
        }

        public IActionResult AddCirculars()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectedThisComplaint(ProvideSolutionsVM model, string id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
                string userRole = role.Value;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var idComp = model.RejectedComplaintVM.UploadsComplainteId;
                var rejected = new ComplaintsRejected()
                {
                    UserId = subuser.Id,
                    RejectedProvName = subuser.FullName,
                    UploadsComplainteId = model.RejectedComplaintVM.UploadsComplainteId,

                    reume = model.RejectedComplaintVM.reume,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.ComplaintsRejecteds.Add(rejected);
                await _context.SaveChangesAsync();


                var upComp = await _compReop.FindAsync(idComp);
                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                if (dbComp != null)
                {
                    dbComp.StatusCompalintId = 3;
                    dbComp.StagesComplaintId = 4;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllComplaints));

            }

            return NotFound();

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


        public async Task<IActionResult> ReportManagement()
        {
            return View();
        }


        public JsonResult headSumitionjson(int type)
        {
            var c1 = "c8145422-a2d6-4c6f-b324-a095232d438f";
            var c2 = "e42ffb08-a972-49de-acd6-ea287ea66aca";
            var c3 = 0;
            var c4 = 0;
            var c5 = 0;
            var c6 = 0;
            var c7 = 0;
            var c8 = 0;
            switch (type)
            {
                case 1: c1 = "c8145422-a2d6-4c6f-b324-a095232d438f"; c2 = "e42ffb08-a972-49de-acd6-ea287ea66aca"; c3 = 3; c4 = 4; c5 = 2; c6 = 1; c7 = 1; break;
                case 2: c1 = "c8145422-a2d6-4c6f-b324-a095232d438f"; c2 = "e42ffb08-a972-49de-acd6-ea287ea66aca"; c3 = 6; c4 = 10; c5 = 7; c6 = 6; c7 = 9; break;
                case 3: c1 = "c8145422-a2d6-4c6f-b324-a095232d438f"; c2 = "e42ffb08-a972-49de-acd6-ea287ea66aca"; c3 = 12; c4 = 14; c5 = 13; c6 = 11; c7 = 11; break;
                case 4: c1 = "c8145422-a2d6-4c6f-b324-a095232d438f"; c2 = "e42ffb08-a972-49de-acd6-ea287ea66aca"; c3 = 16; c4 = 18; c5 = 17; c6 = 15; c7 = 15; break;
            }

            //الكود الخاص بالحصائيات
            float compRecord = _context.UploadsComplaintes.Where(c => c.TypeComplaint.Id == c1).Count();
            float constraint = _context.UploadsComplaintes.Where(c => c.TypeComplaint.Id == c2).Count();
            //float comppunsit = detiltranreps.List().Where(c => c.TransaFID.TransType == c4).Count();
            //float compInvdSucs = detiltranreps.List().Where(c => c.TransaFID.TransType == c5).Count();

            ////عدد المحاضر والتقارير

            //float InvesPreparCount = InvesPreparRepos.List().Count();
            //float InvesReportCount = InvesReportsRepos.List().Count();
            ////الكود الخاص بالنسب 

            ////نسبة الواردة
            //float compRecordRate = compRecord / (compRecord + constraint + comppunsit + compInvdSucs) * 100;
            //compRecordRate.ToString("0.00");
            ////end
            ////نسبة المقيدة
            //float constraintRate = constraint / (compRecord + constraint + comppunsit + compInvdSucs) * 100;

            ////end
            ////نسبة المحالة
            //float compPunsitRate = comppunsit / (compRecord + constraint + comppunsit + compInvdSucs) * 100;
            //compPunsitRate.ToString("");
            ////end
            ////نسبة المنجزة
            //float compInvdSucsRate = compInvdSucs / (compRecord + constraint + comppunsit + compInvdSucs) * 100;
            //compInvdSucsRate.ToString("0.00");
            ////end
            return Json(new
            {
                a = compRecord,
                b = constraint,
                //c = comppunsit,
                //d = compInvdSucs,
                //Aa =
                //compRecordRate.ToString("0.00"),
                //Bb = constraintRate.ToString("0.00"),
                //Cc = compPunsitRate.ToString("0.00"),
                //Dd = compInvdSucsRate.ToString("0.00"),
                //PrCount = InvesPreparCount,
                //ReCount = InvesReportCount

            });

        }

    }
}
