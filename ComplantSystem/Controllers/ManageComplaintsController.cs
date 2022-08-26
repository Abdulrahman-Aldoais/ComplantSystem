using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    [Authorize(Roles = "AdminGeneralFederation,AdminGovernorate,AdminDirectorate,AdminVillages")]
    public class ManageComplaintsController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;
        private readonly ICompalintRepository _compReop;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISolveCompalintService solveCompalintService;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public ManageComplaintsController(
            ILocationRepo<Governorate> governorate,
            ILocationRepo<Directorate> directorate,
            ILocationRepo<SubDirectorate> subDirectorate,
            ILocationRepo<Village> village,
            ICategoryService service,
            ICompalintRepository compReop,
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
            this.userManager = userManager;
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

        public async Task<IActionResult> AllComplaints(int? page)
        {

            var currentUser = await userManager.GetUserAsync(User);
            //var Gov = currentUser?.Governorates.Id;


            var allCompalintsVewi = await _compReop.GetAllAsync(g => g.Governorate, d => d.Directorate, b => b.SubDirectorate);
            var compBy = allCompalintsVewi.Where(g => g.Governorate.Id == currentUser.GovernorateId
            && g.Directorate.Id == currentUser.DirectorateId && g.SubDirectorate.Id == currentUser.SubDirectorateId
            && g.StatusCompalint.Id == 1 && g.StagesComplaintId == 1);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.Status = ViewBag.StatusCompalints;
            int totalCompalints = compBy.Count();
            ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(compBy.ToList());
        }


        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _compReop.FindAsync(id);
            return View(compalintDetails);
        }

        public async Task<IActionResult> UpCompalint(string id, UploadsComplainte complainte)
        {
            var upComp = await _compReop.FindAsync(id);
            if (upComp == null) return View("Empty");

            var response = new UploadsComplainte()
            {
                Id = complainte.Id,
                StagesComplaintId = +1,
            };
            await _compReop.UpdatedbCompAsync(complainte);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllComplaints));

        }


        public async Task<IActionResult> ViewRejectedComplaints(int? page)
        {
            var currentUser = await userManager.GetUserAsync(User);

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
