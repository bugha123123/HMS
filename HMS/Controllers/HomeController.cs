using System.Diagnostics;
using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, IAuthService authService, UserManager<User> userManager)
        {
            _logger = logger;
            _authService = authService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
          return View();
        }

        

                public async Task<IActionResult> bookappointment()
        {
            return View();
        }

    }
}
