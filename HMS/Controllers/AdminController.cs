using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IPatientService _patientService;
        public AdminController(IAdminService adminService, IPatientService patientService)
        {
            _adminService = adminService;
            _patientService = patientService;
        }

        public IActionResult dashboard()
        {
            return View();
        }
        public async Task<IActionResult> patients(string? query, int page = 1, int pageSize = 5)
        {
          
            var patients = await _patientService.FilterUsers(query, page, pageSize);

            // Get total count for pagination calculation
            var totalPatients = await _patientService.FilterUsers(query, 1, int.MaxValue);
            var totalPages = (int)Math.Ceiling((double)totalPatients.Count() / pageSize);

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;

            return View(patients);
        }

        public IActionResult doctors()
        {
            return View();
        }
        
        public IActionResult requests()
        {
            return View();
        }

        public async Task<IActionResult> appointments(string? query, DepartmentType? DepartmentSpecialization, AppointmentStatus? status)
        {
            // Get the filtered list of appointments from the service
            var appointments = await _adminService.Admin_GetAppointments(query, DepartmentSpecialization, status);

            // Return the filtered appointments to the view
            return View(appointments);
        }

        public IActionResult departments()
        {
            return View();
        }

        public async Task<IActionResult> Admin_ScheduleAppointmentAction(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes, int hospitalId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _adminService.Admin_ScheduleAppointment(PatientUserName, departmentId, DoctorId, date, time, Notes, hospitalId);
                    return RedirectToAction("Appointments", "Admin");
                }
                return RedirectToAction("Appointments", "Admin");

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IActionResult> Admin_CancelAppointment(int AppointmentId)
        {
            if (ModelState.IsValid)
            {
                await _adminService.Admin_CancelAppointment(AppointmentId);
                return RedirectToAction("appointments", "Admin");
            }
            return RedirectToAction("appointments", "Admin");

        }

        public async Task<IActionResult> Admin_ApproveDoctorApplication(int ApplicationId)
        {
            if (ModelState.IsValid)
            {
                await _adminService.ApproveApplication(ApplicationId);
                return RedirectToAction("requests", "Admin");
            }
            return RedirectToAction("requests", "Admin");

        }
        public async Task<IActionResult> Admin_RejectDoctorApplication(int ApplicationId)
        {
            if (ModelState.IsValid)
            {
                await _adminService.RejectDoctorApplication(ApplicationId);
                return RedirectToAction("requests", "Admin");
            }
            return RedirectToAction("requests", "Admin");

        }
    }
}
