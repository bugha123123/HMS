﻿using HMS.DB;
using HMS.Interface;
using HMS.Model;
using HMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        
            var totalAppointments = allAppointments.Count();
            var totalPages = (int)Math.Ceiling(totalAppointments / (double)pageSize);

            
            var appointmentsToDisplay = allAppointments
                .Skip((page - 1) * pageSize)  
                .Take(pageSize)               
                .ToList();

            // Pass the appointments and paging info to the view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
           

            return View(appointmentsToDisplay);
        }

        [Authorize]
        public async Task<IActionResult> PatientMedicalRecords(string source)
        {
            var result = await _docservice.GetPatientMedicalRecord(source);
            return View(result);
        }

        [Authorize]
        public IActionResult doctorapplication()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Patients()
        {
            var results = await _docservice.GetAllPatients();
            return View(results);
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
                await _docservice.CancelAppointment(AppointmentId);
                return RedirectToAction("Index", "Doctor");
            }
            return RedirectToAction("Dreviewnotification", "Doctor");

        }
        public async Task<IActionResult> Doctor_SaveNote(int AppointmentId, string DoctorNote, int NotificationId)
        {

            // not using ModelState.IsValid because DoctorNote can be saved as a null

            await _docservice.SaveDoctorNote(AppointmentId, DoctorNote);

                return RedirectToAction("Dreviewnotification", "Doctor", new { NotificationId });

            

        
          

        }

        public async Task<IActionResult> DismissNotification(int AppointmentId)
        {
            if (ModelState.IsValid)
            {
                await _notificationservice.DismissNotification(AppointmentId);
                return RedirectToAction("Index", "Doctor");
            }
            return RedirectToAction("Index", "Doctor");

        }

    }
}
