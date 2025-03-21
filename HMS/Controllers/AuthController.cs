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
        public IActionResult forgotpassword()
        {
            return View();
        }
        public IActionResult resetpassword()
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

        public async Task<IActionResult> SendForgotPasswordGmail(string email)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("forgotpassword","Auth");
            }

            await _authService.SendForgetPasswordEmail(email);
            TempData["Success"] = "Check your inbox";
            return RedirectToAction("forgotpassword", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string newPassword, string confirmNewPassword, string token)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Something went wrong! Please try again.";
                return RedirectToAction("ResetPassword", "Auth");
            }

            try
            {
                await _authService.ResetPassword(email, newPassword, confirmNewPassword, token);

                TempData["Success"] = "Password reset successful. You can now log in.";
                return RedirectToAction("signin", "Auth");
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("resetpassword", "Auth");
            }
        }



    }
}
