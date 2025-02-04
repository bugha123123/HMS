using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult dashboard()
        {
            return View();
        }
        public IActionResult patients()
        {
            return View();
        }
        public IActionResult doctors()
        {
            return View();
        }
        public IActionResult appointments()
        {
            return View();
        }

        public IActionResult departments()
        {
            return View();
        }
    }
}
