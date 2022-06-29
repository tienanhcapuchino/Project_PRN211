using Microsoft.AspNetCore.Mvc;

namespace Project_PRN211.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/Index.cshtml");
        }
    }
}
