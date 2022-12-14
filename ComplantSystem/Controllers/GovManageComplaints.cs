using ComplantSystem.Data.Base;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models;
using ComplantSystem.Service;
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

namespace ComplantSystem.Controllers
{

    [Authorize(Roles = "AdminGovernorate")]
    public class GovManageComplaintsController : Controller
    {


        private readonly IUserService _userService;
        private readonly ICompalintRepository _compReop;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public GovManageComplaintsController(

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
            var currentUser = await _userManager.GetUserAsync(User);



            //-------------أحصائيات بالمستخدمين التابعين لنفس مديرية الموضف--------------------//


            List<UsersIn> usersIn = new List<UsersIn>();
            usersIn = ViewBag.totalUserSubDir;

            List<ApplicationUser> applicationUsers = await _context.Users
                .Where(s => s.GovernorateId == currentUser.GovernorateId && s.RoleId == 3)
                .Include(su => su.Directorate).ToListAsync();

            //Totalcountuser
            int TotalUsers = applicationUsers.Count();

            ViewBag.Users = TotalUsers;

            //total Govermentuser
            ViewBag.totalUserSubDir = applicationUsers.GroupBy(j => j.DirectorateId).Select(g => new UsersIn
            {
                Name = g.First().Directorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمستخدمين التابعين لنفس مديرية الموضف--------------------//



            //-------------أحصائيات بالمزارعين التابعين لنفس مديرية الموضف--------------------//


            List<UsersIn> usersBenfIn = new List<UsersIn>();
            usersBenfIn = ViewBag.totaBenflUserSubDir;

            List<ApplicationUser> applicationBenfUsers = await _context.Users
                .Where(s => s.GovernorateId == currentUser.GovernorateId && s.RoleId == 5)
                .Include(su => su.Directorate).ToListAsync();

            //Totalcountuser
            int TotalBenfUsers = applicationBenfUsers.Count();

            ViewBag.BenfUsers = TotalBenfUsers;

            //total Govermentuser
            ViewBag.totalBenfUserSubDir = applicationBenfUsers.GroupBy(j => j.DirectorateId).Select(g => new UsersIn
            {
                Name = g.First().Directorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalBenfUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمزارعين التابعين لنفس مديرية الموضف--------------------//


            //-------------أحصائيات انواع الشكاوى المقدمة لنفس مديرية الموضف--------------------//



            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
                .Where(s => s.DirectorateId == currentUser.DirectorateId)
                .Include(su => su.TypeComplaint).ToListAsync();
            List<TypeCompalints> typeCompalints = new List<TypeCompalints>();
            typeCompalints = ViewBag.GrapComplanrType;

            int totalcomplant = compalints.Count();
            ViewBag.Totalcomplant = totalcomplant;

            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new TypeCompalints
            {
                Name = g.First().TypeComplaint.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalcomplant
            }).ToList();




            //------------- نهاية أحصائيات انواع الشكاوى المقدمة لنفس مديرية الموضف--------------------//


            //-------------أحصائيات حالات الشكاوى المقدمة لنفس مديرية الموضف--------------------//


            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
                .Where(s => s.GovernorateId == currentUser.GovernorateId)
                .Include(su => su.StatusCompalint).ToListAsync();
            List<StutusCompalints> stutusCompalints = new List<StutusCompalints>();
            stutusCompalints = ViewBag.GrapComplanrStutus;

            int totalStutuscomplant = stutuscompalints.Count();
            ViewBag.TotalStutusComplant = totalStutuscomplant;

            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId).Select(g => new StutusCompalints
            {
                Name = g.First().StatusCompalint.Name,
                TotalCountStutus = g.Count().ToString(),
                stutus = (g.Count() * 100) / totalStutuscomplant
            }).ToList();






            //------------- نهاية أحصائيات حالات الشكاوى المقدمة لنفس مديرية الموضف--------------------//
            return View();
        }


        public class TypeCompalints
        {
            public string Name { get; set; }

            public string TotalCount { get; set; }
            public double TypeComp { get; set; }

        }

        public class StutusCompalints
        {
            public string Name { get; set; }

            public string TotalCountStutus { get; set; }
            public double stutus { get; set; }

        }

        public class UsersIn
        {

            public string Name { get; set; }

            public string totalUsers { get; set; }
            public double Users { get; set; }

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



        public async Task<IActionResult> ViewUsers()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var result = await _context.Users.Where(d => d.UserId == currentUser.IdentityNumber && d.EmailConfirmed != false)
                 .OrderByDescending(d => d.CreatedDate)
                 .Include(g => g.Governorate)
                 .Include(g => g.Directorate)
                 .Include(g => g.SubDirectorate)
                 .ToListAsync();


            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;





            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

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

        public async Task<IActionResult> DisbleOrEnableUser(string id)
        {
            await _userService.EnableAndDisbleUser(id);
            return RedirectToAction(nameof(ViewUsers));


        }
        public async Task<IActionResult> ViewRejectedComplaints(int? page)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var rejectedComplaints = await _compReop.GetAllAsync(g => g.Governorate, n => n.StatusCompalint);
            var Getrejected = rejectedComplaints.Where(g => g.Governorate.Id == currentUser.GovernorateId
            && g.StatusCompalint.Id == 3 && g.StagesComplaint.Id == 1);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);

        }

        public async Task<IActionResult> BeneficiariesAccount()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var result = await _context.Users.Where(r => r.RoleId == 6 && r.GovernorateId == currentUser.GovernorateId)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            return View(result.ToList());

        }

        public async Task<IActionResult> SolutionComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var rejectedComplaints = await _compReop.GetAllAsync(
                 g => g.Governorate,
                d => d.Directorate,
                s => s.SubDirectorate,
                n => n.StatusCompalint,
                st => st.StagesComplaint);
            var Getrejected = rejectedComplaints
                .Where(g => g.Directorate.Id == currentUser.DirectorateId
                && g.StatusCompalint.Id == 2 && g.StagesComplaint.Id == 1);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);
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
            return RedirectToAction("AllUpComplaints");

        }

        public async Task<IActionResult> RejectedThisComplaint(string id, UploadsComplainte complainte)
        {

            var upComp = await _compReop.FindAsync(id);
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
            if (dbComp != null)
            {

                dbComp.Id = complainte.Id;
                dbComp.StatusCompalintId = 3;


                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewRejectedComplaints));

        }


        public async Task<IActionResult> RejectedComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var rejectedComplaints = await _compReop.GetAllAsync(
                g => g.Governorate,
                d => d.Directorate,
                s => s.SubDirectorate,
                n => n.StatusCompalint,
                st => st.StagesComplaint);
            var Getrejected = rejectedComplaints.Where(g => g.Governorate.Id == currentUser.GovernorateId
            && g.StatusCompalint.Id == 3 && g.StagesComplaint.Id == 4);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            //ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);

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
                return RedirectToAction("AllUpComplaints");

            }

            return NotFound();


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

                var complaintsRejected = new ComplaintsRejected()
                {
                    UserId = subuser.Id,
                    RejectedProvName = subuser.FullName,
                    UploadsComplainteId = model.RejectedComplaintVM.UploadsComplainteId,
                    RejectedUserProvIdentity = subuser.IdentityNumber,
                    reume = model.RejectedComplaintVM.reume,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.ComplaintsRejecteds.Add(complaintsRejected);
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
                return RedirectToAction("AllUpComplaints");

            }

            return NotFound();


        }

        public async Task<IActionResult> AllUpComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var allComp = _compReop.GetAll().Where(g => g.UserId == currentUser.UserId
            && g.StatusCompalint.Id == 3); ;
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddCommunication()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            int SubDirctoty = currentUser.SubDirectorateId;
            var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues(SubDirctoty);
            ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
            ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "FullName");



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommunication(AddCommunicationVM communication)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                int SubDirctoty = currentUser.SubDirectorateId;
                var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues(SubDirctoty);
                ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
                ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "Name");


                var currentName = currentUser.FullName;
                var currentPhone = currentUser.PhoneNumber;
                var currentGov = currentUser.GovernorateId;
                var currentDir = currentUser.DirectorateId;
                var currentSub = currentUser.SubDirectorateId;

                await _compReop.CreateCommuncationAsync(new AddCommunicationVM
                {
                    Titile = communication.Titile,
                    NameUserId = communication.NameUserId,
                    reason = communication.reason,
                    CreateDate = communication.CreateDate,
                    TypeCommuncationId = communication.TypeCommuncationId,
                    UserId = currentUser.Id,
                    BenfName = currentName,
                    BenfPhoneNumber = currentPhone,
                    GovernorateId = currentGov,
                    DirectorateId = currentDir,
                    SubDirectorateId = currentSub,

                });

                return RedirectToAction("AllCommunication");
            }
            return View(communication);
        }



    }
}
