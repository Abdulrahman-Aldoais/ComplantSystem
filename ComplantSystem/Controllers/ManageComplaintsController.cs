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
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    [Authorize(Roles = "AdminGeneralFederation,AdminGovernorate,AdminDirectorate")]
    public class ManageComplaintsController : Controller
    {

        private readonly ICompalintRepository _compReop;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public ManageComplaintsController(

            ICategoryService service,
            ICompalintRepository compReop,
            UserManager<ApplicationUser> userManager,

            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {

            _compReop = compReop;
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




        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
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
            return RedirectToAction("AllComplaints");

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
                    dbComp.StagesComplaintId = 2;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("AllComplaints");

            }

            return NotFound();

        }

        public async Task<IActionResult> ViewRejectedComplaints(int? page)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var rejectedComplaints = await _compReop.GetAllAsync(g => g.Governorate, n => n.StatusCompalint);
            var Getrejected = rejectedComplaints.Where(g => g.Governorate.Id == currentUser.GovernorateId
            && g.Directorate.Id == currentUser.DirectorateId && g.SubDirectorate.Id == currentUser.SubDirectorateId

            && g.StatusCompalint.Id == 3);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);

        }

    }
}
