using Microsoft.AspNetCore.Mvc;

namespace Project_PRN211.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InfoGuest()
        {
            return View();
        }
        public IActionResult UpdateGuest()
        {
            return View("InfoGuest");
        }
    }
}
