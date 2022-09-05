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
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem
{

    [Authorize(Roles = "Beneficiarie")]
    public class BeneficiarieController : Controller
    {

        private readonly ICompalintRepository _service;
        private readonly IUserService userService;
        private readonly ICompalintRepository compalintRepository;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppCompalintsContextDB _context;

        public BeneficiarieController(

            ICompalintRepository service,
            IUserService userService,
            ICompalintRepository compalintRepository,
            IWebHostEnvironment env,
              UserManager<ApplicationUser> userManager,
            AppCompalintsContextDB context)
        {


            _service = service;
            this.userService = userService;
            this.compalintRepository = compalintRepository;
            _context = context;
            _env = env;
            this.userManager = userManager;
        }


        private string UserId
        {
            get
            {
                //var IdentityUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //IdentityUser.
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }






        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var Identity = currentUser.IdentityNumber;
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");


            var result = _service.GetBy(Identity);

            int totalCompalints = result.Count();

            ViewBag.totalCompalints = totalCompalints;

            return View(result.ToList());

        }


        public async Task<IActionResult> ViewResolvedComplaints()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var Identity = currentUser.IdentityNumber;
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = _service.GetAllResolvedComplaints(Identity);
            return View(rejectedComplaints.ToList());

        }

        public async Task<IActionResult> ViewRejectedComplaints()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var Identity = currentUser.IdentityNumber;
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = _service.GetAllRejectedComplaints(Identity);



            return View(rejectedComplaints.ToList());

        }



        //[HttpGet]
        //public JsonResult GetDirectorates(int GovernorateId)
        //{
        //    var g = governorate.Find(GovernorateId);
        //    var dire = directorate.ListByFilter(cc => cc.Governorate == g);
        //    return Json(new SelectList(dire, "Id", "Name"));
        //}







        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;



            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputCompmallintVM model)
        {


            if (!ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                var Identity = currentUser.IdentityNumber;

                var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
                ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
                ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

                var newName = Guid.NewGuid().ToString(); //rre-rewrwerwer-gwgrg-grgr
                var extension = Path.GetExtension(model.File.FileName);
                var fileName = string.Concat(newName, extension); // newName + extension
                var root = _env.WebRootPath;
                var path = Path.Combine(root, "Uploads", fileName);

                using (var fs = System.IO.File.Create(path))
                {
                    await model.File.CopyToAsync(fs);
                }


                //await _service.CreateAsync(data);
                await _service.CreateAsync2(new InputCompmallintVM
                {
                    TitleComplaint = model.TitleComplaint,
                    TypeComplaintId = model.TypeComplaintId,
                    DescComplaint = model.DescComplaint,
                    PropBeneficiarie = model.PropBeneficiarie,
                    GovernorateId = currentUser.GovernorateId,
                    DirectorateId = currentUser.DirectorateId,
                    SubDirectorateId = currentUser.SubDirectorateId,

                    UserId = Identity,
                    StagesComplaintId = model.StagesComplaintId = 1,
                    OriginalFileName = model.File.FileName,
                    FileName = fileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                });

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> AllCommunication()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var UserId = currentUser.Id;
            var communicationDropdownsData = await _service.GetAddCommunicationDropdownsValues();

            ViewBag.TypeCommunication = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Name");


            var result = _service.GetCommunicationBy(UserId);

            int totalCompalints = result.Count();

            ViewBag.totalCompalints = totalCompalints;

            return View(result.ToList());
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddCommunication()
        {

            var currentUser = await userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            var communicationDropdownsData = await _service.GetAddCommunicationDropdownsValues();
            ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
            ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "FullName");



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommunication(AddCommunicationVM communication)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                var communicationDropdownsData = await _service.GetAddCommunicationDropdownsValues();
                ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
                ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "Name");


                var currentName = currentUser.FullName;
                var currentPhone = currentUser.PhoneNumber;
                var currentGov = currentUser.GovernorateId;
                var currentDir = currentUser.DirectorateId;
                var currentSub = currentUser.SubDirectorateId;

                await _service.CreateCommuncationAsync(new AddCommunicationVM
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

                return RedirectToAction(nameof(AllCommunication));
            }
            return View(communication);
        }


        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            //var compalintDetails = await _service.FindAsync(id);
            //var ComplantList = await _context.UploadsComplainte.Include(a => a.Governorates).Include(a => a.Directorates).Include(a => a.SubDirectorates).Include(a => a.Villages).Include(a => a.TypeComplaint).Where(m => m.Id == id).FirstOrDefaultAsync();
            var ComplantList = await _service.FindAsync(id);
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

        public async Task<IActionResult> Yes(string idS)
        {
            if (idS == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var so = await _context.Compalints_Solutions.Where(a => a.Id == idS).FirstOrDefaultAsync();

                //if(cc.StagesComplaintId==1)
                //  {
                //      cc.StagesComplaintId = 2;
                //  }
                //elseIf(cc.StagesComplaintId=2)
                //      {
                //      cc.StagesComplaintId = 3;
                //  }
                so.IsAccept = true;
                _context.Compalints_Solutions.Update(so);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
        }

        public async Task<IActionResult> No(string idS)
        {
            if (idS == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var so = await _context.Compalints_Solutions.Where(a => a.Id == idS).FirstOrDefaultAsync();
                var cc = await _context.UploadsComplaintes.Where(m => m.Id == so.UploadsComplainteId).FirstOrDefaultAsync();
                cc.StagesComplaintId += 3;
                so.SolutionProvIdentity = so.SolutionProvIdentity;
                _context.Compalints_Solutions.Update(so);
                await _context.SaveChangesAsync();
                _context.UploadsComplaintes.Update(cc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
        }


        [AllowAnonymous]
        public async Task<IActionResult> RejectedComplaints()
        {
            var allCompalints = await _service.GetAllAsync(n => n.StatusCompalintId == 2);
            return View(allCompalints);
        }




        [AllowAnonymous]
        public async Task<IActionResult> FilterCompalintsBySearch(string term)
        {

            var allCompalints = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(term))
            {

                var result = _context.UploadsComplaintes.Where(
                 u => u.TitleComplaint == term
                 || u.DescComplaint == term);
                return View("Index", result);
            }
            return View("Index", allCompalints);
            //return result;
        }


        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await _service.FindAsync(id);
            if (selectedFile == null)
            {
                return NotFound();
            }



            var path = "~/Uploads/" + selectedFile.FileName;
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");
            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        }



        public async Task<IEnumerable<Proposal>> GetAllAsync() => await _context.Proposals.ToListAsync();

        public async Task<IActionResult> AllProposals()
        {
            var allProposals = await GetAllAsync();

            return View(allProposals);
        }


        public async Task AddProposalAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
        }



        public IActionResult AddProposals()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProposals([Bind("TitileProposal,DescProposal")] Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return View(proposal);
            }
            await AddProposalAsync(proposal);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IEnumerable<Proposal>> GetAllProposalsAsync() => await _context.Proposals.ToListAsync();

        public async Task<IActionResult> DetailsProposal(string id)
        {
            var detailsProposal = await GetByProposalIdAsync(id);
            return View(detailsProposal);
        }

        public async Task<Proposal> GetByProposalIdAsync(string id)
        {
            var proposalDetails = await _context.Proposals

                .FirstOrDefaultAsync(p => p.Id == id);
            return proposalDetails;
        }




    }
}
