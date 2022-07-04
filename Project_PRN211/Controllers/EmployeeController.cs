using Microsoft.AspNetCore.Mvc;

namespace Project_PRN211.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateProfile()
        {
            return View();
        }
        public IActionResult ChangePass()
        {
            return View();
        }
    }
}
