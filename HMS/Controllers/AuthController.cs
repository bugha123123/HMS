using HMS.DTO;
using HMS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult signin()
        {
            return View();
        }

        public IActionResult signup()
        {
            return View();
        }
   

        public async Task<IActionResult> SigninUser(LogInDTO logInViewModel)
        {
            if (ModelState.IsValid)
            {
                await _authService.LogInUser(logInViewModel);
                return RedirectToAction("Index", "Home");
            }
            return View("signin", logInViewModel);
        }

        public async Task<IActionResult> SignupUser(RegisterDTO RegisterViewModel,string Role = "Patient")
        {
            if (ModelState.IsValid)
            {
              
                await _authService.RegisterUser(RegisterViewModel, Role);
                return RedirectToAction("Index", "Home");
            }
            return View("signup", RegisterViewModel);
        }

        public async Task<IActionResult> SignoutUser()
        {

            await _authService.LogOutUser();
            return RedirectToAction("signin", "Auth");


        }

    }
}
