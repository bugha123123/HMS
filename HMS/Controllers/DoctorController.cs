using HMS.DB;
using HMS.Interface;
using HMS.Model;
using HMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _docservice;
        private readonly IAdminService _adminservice;
        private readonly INotificationService _notificationservice;
        private readonly AppDbContextion _db;
        public DoctorController(IDoctorService docservice, IAdminService adminservice, INotificationService notificationservice, AppDbContextion db)
        {
            _docservice = docservice;
            _adminservice = adminservice;
            _notificationservice = notificationservice;
            _db = db;
        }
        [Authorize]
        public async Task<IActionResult> Index(DateTime? when, string? query, int page = 1, int pageSize = 3)
        {
            var allAppointments = await _docservice.FilterAppointment(when, query);

            // Calculate the total number of pages
            var totalAppointments = allAppointments.Count();
            var totalPages = (int)Math.Ceiling(totalAppointments / (double)pageSize);

            // Get the appointments for the current page
            var appointmentsToDisplay = allAppointments
                .Skip((page - 1) * pageSize)  // Skip the appointments for the previous pages
                .Take(pageSize)               // Take only the specified number of appointments
                .ToList();

            // Pass the appointments and paging info to the view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
           

            return View(appointmentsToDisplay);
        }
        [Authorize]
        public IActionResult doctorapplication()
        {
            return View();
        }
        public async Task<IActionResult> Dreviewnotification(int NotificationId)
        {
            var result = await _notificationservice.Doctor_GetNotificationById(NotificationId);
            result.IsRead = true;
                await _db.SaveChangesAsync();
            return View(result);
        }
        [Authorize]
        public async Task<IActionResult> reschedule(int appointmentId)
        {
            var result = await _docservice.GetAppointmentById(appointmentId);
            return View(result);
        }
        [Authorize]
        public async Task<IActionResult> appointmentdetails(int appId)
        {
            var result = await _docservice.GetAppointmentById(appId);
            return View(result);
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


        [HttpPost]
        public async Task<IActionResult> Doctor_ScheduleAppointment(int appId)
        {
            if (ModelState.IsValid)
            {
                await _docservice.Doctor_ScheduleAppointment(appId);
                return RedirectToAction("Index", "Doctor");
            }
            return RedirectToAction("Index", "Doctor");
        }



        public async Task<IActionResult> Doctor_ReScheduleAppointment(int AppointmentId, DateTime time, DateTime date, string reason)
        {
            if (ModelState.IsValid)
            {
                await _docservice.Doctor_ReScheduleAppointment(AppointmentId, time, date, reason);

                // Set toast message to indicate successful rescheduling
                ViewData["toast"] = "Appointment rescheduled successfully.";

                return RedirectToAction("Index", "Doctor");
            }

            return RedirectToAction("Index", "Doctor");
        }

        public async Task<IActionResult> Doctor_CancelAppointment(int AppointmentId)
        {
            if (ModelState.IsValid)
            {
                await _adminservice.Admin_CancelAppointment(AppointmentId);
                return RedirectToAction("signup", "Auth");
            }
            return RedirectToAction("appointmentdetails", "Doctor");

        }
        
    }
}
