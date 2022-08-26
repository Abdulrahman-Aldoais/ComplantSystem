using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Controllers
{
    public class DirManageComplaints : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
