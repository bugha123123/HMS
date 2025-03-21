using System.Diagnostics;
using HMS.DTO;
using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static HMS.Model.User;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
      private readonly IPatientService _patientService;
        private readonly IDoctorService _docservice;

        public HomeController(IPatientService petientService, IDoctorService docservice)
        {
            _patientService = petientService;
            _docservice = docservice;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
          return View();
        }
        [Authorize]
        public async Task<IActionResult> medicalrecords()
        {
            var MedicalRecords = await _patientService.GetMedicalHistoryAsync();
            return View(MedicalRecords);
        }


        [Authorize]
        public async Task<IActionResult> bookappointment()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Profile()
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

        

               public async Task<IActionResult> Patient_CancelAppointment(int AppointmentId)
        {
            if (ModelState.IsValid)
            {
                await _docservice.CancelAppointment(AppointmentId);
                return RedirectToAction("signup", "Auth");
            }
            return RedirectToAction("appointmentdetails", "Doctor");

        }

        public async Task<IActionResult> Patient_MarkNotificationAsRead(int NotificationId)
        {
            if (ModelState.IsValid)
            {
                await _patientService.MarkNotificationAsRead(NotificationId);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> EditProfile(IFormFile ProfilePicture)
        {
            if (ProfilePicture == null || ProfilePicture.Length == 0)
            {
                TempData["ErrorMessage"] = "No file uploaded."; 
                return RedirectToAction("Profile", "Home"); 
            }

            await _patientService.EditProfile(ProfilePicture);
            return RedirectToAction("Profile", "Home");
        }
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (!ModelState.IsValid)
            {
                // Set an error message to TempData
                TempData["ErrorMessage"] = "Please correct the errors in the form.";
                return RedirectToAction("Profile", "Home");
            }

            try
            {
                await _patientService.ChangePassword(oldPassword, newPassword);

                // Set a success message to TempData
                TempData["Success"] = "Password changed successfully.";
                return RedirectToAction("Profile", "Home"); 
            }
            catch (UnauthorizedAccessException)
            {
                TempData["ErrorMessage"] = "The current password is incorrect.";
                return RedirectToAction("Profile", "Home");
            }
            catch (Exception ex)
            {
                // Set a general error message
                TempData["ErrorMessage"] = "An error occurred while changing the password: " + ex.Message;
                return RedirectToAction("Profile", "Home"); 
            }
        }


        public async Task<IActionResult> ToggleMedicalAccess(MedicalAccessStatus accessStatus)
        {
            await _patientService.ToggleMedicalRecordsAccess(accessStatus);
            return RedirectToAction("Profile", "Home");
        }




    }
}
