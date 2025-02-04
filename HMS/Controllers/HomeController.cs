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
      private readonly IPatientService _patientService;

        public HomeController(IPatientService petientService)
        {
            _patientService = petientService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
          return View();
        }
        public async Task<IActionResult> medicalrecords()
        {
            var MedicalRecords = await _patientService.GetMedicalHistoryAsync();
            return View(MedicalRecords);
        }



        public async Task<IActionResult> bookappointment()
        {
            return View();
        }
        
        public async Task<IActionResult> AppointmentBookingSuccess()
        {
            return View();
        }

        public async Task<IActionResult> AppointmentBookingFailure()
        {
            return View();
        }
        public async Task<IActionResult> BookAnAppointment(string DoctorFullName, DateTime AppointmentDate, DateTime Appointmenttime, string PhoneNumber, string HospitalName,string Reason)
        {
            if (ModelState.IsValid)
            {
                await _patientService.BookAppointmentAsync(DoctorFullName, AppointmentDate, Appointmenttime, PhoneNumber, HospitalName, Reason);
                return RedirectToAction("AppointmentBookingSuccess", "Home");
            }
            return RedirectToAction("AppointmentBookingFailure", "Home");

        }
    }
}
