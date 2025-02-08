using HMS.DTO;
using HMS.Interface;
using HMS.Model;
using HMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        public AdminController(IAdminService adminService, IPatientService patientService, IDoctorService doctorService)
        {
            _adminService = adminService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public IActionResult dashboard()
        {
            return View();
        }
        
      public async Task<IActionResult> appointmentdetails(int AppointmentId)
        {
            var Appointment = await _adminService.GetAppointmentById(AppointmentId);
            return View(Appointment);
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
        public async Task<IActionResult> doctors(string? query, Department? department)
        {
            // Call FilterDoctors to get the filtered list of doctors
            var FilteredDoctors = await _doctorService.FilterDoctors(query, department);
            var Doctors = await _doctorService.GetAllDoctors();

            if (query is null || department is null) {
                return View(Doctors);
            }
            return View(FilteredDoctors);
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


        public IActionResult setpassword()
        {
            
            return View();
        }
        public async Task<IActionResult> Admin_ScheduleAppointmentAction(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes, int hospitalId)
        {
            try
            {
              
                    await _adminService.Admin_ScheduleAppointment(PatientUserName, departmentId, DoctorId, date, time, Notes, hospitalId);
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
        public async Task<IActionResult> Admin_AddNewPatient(string email, string contactNumber, int age, string gender)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("patients", "Admin"); // failed validation
            }

            var result = await _adminService.AddNewPatient(email, contactNumber, age, gender);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Patient registered successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction("patients", "Admin");
        }

        public async Task<IActionResult> Patient_SetPassword(string email, string newPassword)
        {
            
                var result = await _patientService.SetPassword(email, newPassword);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Your password has been set successfully!";
                    return RedirectToAction("signin", "Auth");
                }
            return RedirectToAction("setpassword", "Admin");


        }


        public async Task<IActionResult> Admin_DeletePatient(string PatientId)
        {
            if (ModelState.IsValid)
            {
  await _adminService.DeletePatient(PatientId);   

          
            return RedirectToAction("patients", "Admin");
            }
            return RedirectToAction("patients", "Admin");



        }

    }
}
