using ComplantSystem.Const;
using ComplantSystem.Data.Base;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Hubs;
using ComplantSystem.Models;
using ComplantSystem.Models.Statistics;
using ComplantSystem.Service;
using ComplantSystem.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<NotefcationHub> notificationHub;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public GeneralFederationController(

            ICategoryService service,
            ICompalintRepository compReop,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IHubContext<NotefcationHub> notificationHub,
            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {

            _compReop = compReop;
            _userService = userService;
            _userManager = userManager;
            this.notificationHub = notificationHub;
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

        //public void OnGet()
        //{

        //}
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

            //------------- أحصائيات بالمستخدمين في كل محافظة --------------------//


            List<UsersInStatistic> usersIn = new List<UsersInStatistic>();
            usersIn = ViewBag.totalGovermentuser;

            List<ApplicationUser> applicationUsers = await _context.Users

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalUsers = applicationUsers.Count();

            ViewBag.Users = TotalUsers;

            //total Govermentuser
            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new UsersInStatistic
            {
                Name = g.First().Governorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمستخدمين --------------------//


            //-------------أحصائيات انواع الشكاوى --------------------//

            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
                .Include(su => su.TypeComplaint).ToListAsync();
            List<TypeCompalintStatistic> typeCompalints = new List<TypeCompalintStatistic>();
            typeCompalints = ViewBag.GrapComplanrType;

            int totalcomplant = compalints.Count();
            ViewBag.Totalcomplant = totalcomplant;

            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new TypeCompalintStatistic
            {
                Name = g.First().TypeComplaint.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalcomplant
            }).ToList();




            //------------- نهاية أحصائيات انواع الشكاوى --------------------//


            //-------------أحصائيات حالات الشكاوى --------------------//


            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
                .Include(su => su.StatusCompalint).ToListAsync();
            List<StutusCompalintStatistic> stutusCompalints = new List<StutusCompalintStatistic>();
            stutusCompalints = ViewBag.GrapComplanrStutus;

            int totalStutuscomplant = stutuscompalints.Count();
            ViewBag.TotalStutusComplant = totalStutuscomplant;

            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId).Select(g => new StutusCompalintStatistic
            {
                //id = 
                Name = g.First().StatusCompalint.Name,
                TotalCountStutus = g.Count().ToString(),
                stutus = (g.Count() * 100) / totalStutuscomplant
            }).ToList();

            //------------- نهاية أحصائيات حالات الشكاوى --------------------//



            //-------------  أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//

            List<ApplicationUser> UsersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();


            //Totalcountuser
            int totalCountByRole = applicationUsers.Count();

            ViewBag.TotalCountByRoles = totalCountByRole;

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
            ViewBag.totalUserByRoles = x.GroupBy(j => j.RoleName).Select(g => new UserByRolesStatistic
            {
                RoleName = g.First().RoleName,
                TotalCount = g.Count().ToString(),
                RolsTot = (g.Count() * 100) / totalCountByRole


            }).ToList();


            List<UserByRolesStatistic> gtus = new List<UserByRolesStatistic>();
            gtus = ViewBag.totalUserByRoles;


            //------------------ نهاية أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//


            //-------------  أحصائيات انواع اليلاغات    --------------------//



            List<UsersCommunication> communcations = await _context.UsersCommunications
                .Include(su => su.TypeCommunication).ToListAsync();
            List<TypeCommunicationStatistic> TotalTypeCommuncations = new List<TypeCommunicationStatistic>();

            int totalCommunication = communcations.Count();

            TotalTypeCommuncations = ViewBag.typeCommun;

            ViewBag.TypeCommuncations = communcations.GroupBy(x => x.TypeCommunication).Select(g => new TypeCommunicationStatistic
            {
                Name = g.First().TypeCommunication.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalCommunication
            }).ToList();

            //------------- نهاية أحصائيات انواع اليلاغات --------------------//


            //-------------  أحصائيات عدد اليلاغات    --------------------//


            List<TotalCommunicationStatistic> communicationsIn = new List<TotalCommunicationStatistic>();
            communicationsIn = ViewBag.totalcommunications;

            List<UsersCommunication> communications = await _context.UsersCommunications

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalCommun = communications.Count();

            ViewBag.Commun = TotalCommun;

            //total Govermentuser
            ViewBag.totalcommunications = communications.GroupBy(j => j.GovernorateId).Select(g => new TotalCommunicationStatistic
            {
                Name = g.First().Governorate.Name,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / TotalUsers

            }).ToList();

            //------------- نهاية أحصائيات عدد اليلاغات --------------------//

            return View();
        }


        public async Task<IActionResult> PrintReports()
        {



            //------------- أحصائيات بالمستخدمين في كل محافظة --------------------//


            List<UsersInStatistic> usersIn = new List<UsersInStatistic>();
            usersIn = ViewBag.totalGovermentuser;

            List<ApplicationUser> applicationUsers = await _context.Users

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalUsers = applicationUsers.Count();

            ViewBag.Users = TotalUsers;

            //total Govermentuser
            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new UsersInStatistic
            {
                Name = g.First().Governorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمستخدمين --------------------//


            //-------------أحصائيات انواع الشكاوى --------------------//



            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
                .Include(su => su.TypeComplaint).ToListAsync();
            List<TypeCompalintStatistic> typeCompalints = new List<TypeCompalintStatistic>();
            typeCompalints = ViewBag.GrapComplanrType;

            int totalcomplant = compalints.Count();
            ViewBag.Totalcomplant = totalcomplant;

            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new TypeCompalintStatistic
            {
                Name = g.First().TypeComplaint.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalcomplant
            }).ToList();




            //------------- نهاية أحصائيات انواع الشكاوى --------------------//


            //-------------أحصائيات حالات الشكاوى --------------------//


            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
                .Include(su => su.StatusCompalint).ToListAsync();
            List<StutusCompalintStatistic> stutusCompalints = new List<StutusCompalintStatistic>();
            stutusCompalints = ViewBag.GrapComplanrStutus;

            int totalStutuscomplant = stutuscompalints.Count();
            ViewBag.TotalStutusComplant = totalStutuscomplant;

            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId).Select(g => new StutusCompalintStatistic
            {
                //id = 
                Name = g.First().StatusCompalint.Name,
                TotalCountStutus = g.Count().ToString(),
                stutus = (g.Count() * 100) / totalStutuscomplant
            }).ToList();


            //------------- نهاية أحصائيات حالات الشكاوى --------------------//



            //-------------  أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//

            List<ApplicationUser> UsersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();

            //Totalcountuser
            int totalCountByRole = applicationUsers.Count();

            ViewBag.TotalCountByRoles = totalCountByRole;

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
            ViewBag.totalUserByRoles = x.GroupBy(j => j.RoleName).Select(g => new UserByRolesStatistic
            {
                RoleName = g.First().RoleName,
                TotalCount = g.Count().ToString(),
                RolsTot = (g.Count() * 100) / totalCountByRole

            }).ToList();


            List<UserByRolesStatistic> gtus = new List<UserByRolesStatistic>();
            gtus = ViewBag.totalUserByRoles;


            //------------------ نهاية أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//


            //-------------  أحصائيات انواع اليلاغات    --------------------//

            List<UsersCommunication> communcations = await _context.UsersCommunications
                .Include(su => su.TypeCommunication).ToListAsync();
            List<TypeCommunicationStatistic> TotalTypeCommuncations = new List<TypeCommunicationStatistic>();

            int totalCommunication = communcations.Count();

            TotalTypeCommuncations = ViewBag.typeCommun;

            ViewBag.TypeCommuncations = communcations.GroupBy(x => x.TypeCommunication).Select(g => new TypeCommunicationStatistic
            {
                Name = g.First().TypeCommunication.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalCommunication
            }).ToList();




            //------------- نهاية أحصائيات انواع اليلاغات --------------------//


            //-------------  أحصائيات عدد اليلاغات    --------------------//


            List<TotalCommunicationStatistic> communicationsIn = new List<TotalCommunicationStatistic>();
            communicationsIn = ViewBag.totalcommunications;

            List<UsersCommunication> communications = await _context.UsersCommunications

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalCommun = communications.Count();

            ViewBag.Commun = TotalCommun;

            //total Govermentuser
            ViewBag.totalcommunications = communications.GroupBy(j => j.GovernorateId).Select(g => new TotalCommunicationStatistic
            {
                Name = g.First().Governorate.Name,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / TotalUsers

            }).ToList();

            //------------- نهاية أحصائيات عدد اليلاغات --------------------//
            return View();
        }
        public async Task<IActionResult> AllComplaints()
        {
            var allComp = _compReop.GetAll();
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RejectedComplaints()
        {
            var allComp = _compReop.GetAll().Where(s => s.StatusCompalintId == 3);
            var totaleComp = allComp.Count();
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> AllUpComplaints()
        {
            var allComp = _compReop.GetAll().Where(s => s.StatusCompalintId == 3); ;
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> ViewCompalintUpDetails(string id)
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
        public async Task<IActionResult> SolutionComplaints()
        {
            var allComp = _compReop.GetAll().Where(s => s.StatusCompalintId == 2);
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        //public async Task<IActionResult> UpCompalint(string id, ProvideSolutionsVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var currentUser = await _userManager.GetUserAsync(User);
        //        var claimsIdentity = (ClaimsIdentity)User.Identity;
        //        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //        var role = claimsIdentity.FindFirst(ClaimTypes.Role);
        //        string userRole = role.Value;
        //        string UserId = claim.Value;
        //        var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
        //        var idComp = model.UpComplaint.UploadsComplainteId;
        //        var upComplaint = new UpComplaintCause()
        //        {
        //            UserId = subuser.Id,
        //            UpProvName = subuser.FullName,
        //            UploadsComplainteId = model.UpComplaint.UploadsComplainteId,
        //            UpUserProvIdentity = subuser.IdentityNumber,
        //            Cause = model.UpComplaint.Cause,
        //            DateUp = DateTime.Now,
        //            Role = userRole,


        //        };

        //        _context.UpComplaintCauses.Add(upComplaint);
        //        await _context.SaveChangesAsync();


        //        var upComp = await _compReop.FindAsync(idComp);
        //        var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
        //        if (dbComp != null)
        //        {
        //            dbComp.StatusCompalintId = 2;
        //            dbComp.StagesComplaintId = 4;
        //            await _context.SaveChangesAsync();
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(AllComplaints));



        //    }
        //    return NotFound();
        //}
        // عرض المستخدمين من غير المزارعين
        public async Task<IActionResult> ViewUsers()
        {
            var result = await _context.Users.Where(r => r.RoleId != 5)
                .OrderByDescending(d => d.CreatedDate)
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

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

            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            List<Governorate> GovernorateList = new List<Governorate>();
            GovernorateList = (from d in _context.Governorates select d).ToList();
            GovernorateList.Insert(0, new Governorate { Id = 0, Name = "حدد المحافظة" });
            ViewBag.ViewGover = GovernorateList;
            var newUser = new EditUserViewModel
            {
                //GovernoratesList = await _context.Governorates.ToListAsync(),

                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                IdentityNumber = user.IdentityNumber,
                IsBlocked = user.IsBlocked,
                DateOfBirth = user.DateOfBirth,
                GovernorateId = user.Governorate.Id,
                DirectorateId = user.Directorate.Id,
                SubDirectorateId = user.SubDirectorate.Id,
                RoleId = user.RoleId,

            };

            //ViewBag.ViewGover = newUser.GovernoratesList.ToArray();
            return View(newUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel user)
        {
            //var users = await _userService.GetAllAsync();
            //ViewBag.UserCount = users.Count();

            if (ModelState.IsValid)
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


        public async Task<IActionResult> AccountRestriction()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;
            var result = _userService.GetAllUserBlockedAsync(currentIdUser);



            return View(result.ToList());

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

            return RedirectToAction(nameof(AllCategoriesCommunications));

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
            int SubDirctoty = currentUser.SubDirectorateId;
            var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues(SubDirctoty);

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


        public async Task<IActionResult> AllCirculars()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync(UserRoles.AdminSubDirectorate);
            var adminIds = adminUsers.Select(user => user.Id);
            if (adminIds.Any())
            {
                await notificationHub.Clients.Users(adminIds).SendAsync("ReceiveNotification", "WOOOOOOOOOOOOO");
            }
            return RedirectToAction();
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

        public async Task<IActionResult> UserReport(string Id)
        {
            var comSolution = _context.Compalints_Solutions.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId);
            //.Select(r => new
            //{

            //});

            var AcceptSolution = _context.Compalints_Solutions.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId, a => a.IsAccept);
            var ComplaintsRejecteds = _context.ComplaintsRejecteds.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId);
            var user = await _userService.GetByIdAsync(Id);


            if (user == null)
            {
                return NotFound();
            }

            var result = new UserReportVM
            {
                UserId = user.Id,
                TotlSolutionComp = comSolution.Count(),
                TotlRejectComp = ComplaintsRejecteds.Count(),
                TotlAcceptSolution = AcceptSolution.Count(),
                //Orders = userGroup,
                FullName = user.FullName,
                Gov = user.Governorate.Name,
                Dir = user.Directorate.Name,
                Role = user.RoleName,
                PhonNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };


            return View(result);
        }
        public async Task<IActionResult> BeneficiariesAccount()
        {

            var result = await _context.Users.Where(r => r.RoleId == 5)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            return View(result.ToList());

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

        [HttpGet]
        public async Task<IActionResult> GetDirectorateies(int id)
        {
            List<Directorate> directorate = new List<Directorate>();
            directorate = await _context.Directorates.Where(m => m.GovernorateId == id).ToListAsync();
            return Json(new SelectList(directorate, "Id", "Name"));
        }

        [HttpGet]
        public async Task<IActionResult> GetSubDirectorate(int id)
        {
            List<SubDirectorate> subdirectorate = new List<SubDirectorate>();
            subdirectorate = await _context.SubDirectorates.Where(m => m.DirectorateId == id).ToListAsync();
            return Json(new SelectList(subdirectorate, "Id", "Name"));
        }


        public async Task<IActionResult> DisbleOrEnableUser(string id)
        {
            await _userService.EnableAndDisbleUser(id);
            return RedirectToAction("ViewUsers");


        }


    }
}
