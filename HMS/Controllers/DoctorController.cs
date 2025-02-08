using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _docservice;

        public DoctorController(IDoctorService docservice)
        {
            _docservice = docservice;
        }

        public async Task<IActionResult> Index(DateTime? when, int page = 1, int pageSize = 3)
        {
            var allAppointments = await _docservice.FilterAppointment(when);

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
           

            return View(allAppointments);
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
