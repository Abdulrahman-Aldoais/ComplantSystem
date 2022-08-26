using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Controllers
{
    public class GovManageComplaints : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
