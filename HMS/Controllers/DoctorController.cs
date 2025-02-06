using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _docservice;

        public DoctorController(IDoctorService docservice)
        {
            _docservice = docservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult doctorapplication()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SaveDoctorApplication(DoctorApplication doctorApplication)
        {
            if (ModelState.IsValid)
            {
                await _docservice.SaveDoctorApplicationAsync(doctorApplication);
                return RedirectToAction("Index", "Home");
            }
            return View(doctorApplication); 
        }


    }
}
