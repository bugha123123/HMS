using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult chat()
        {
            return View();
        }
    }
}
