using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Controllers
{
    public class CompalintsMangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
