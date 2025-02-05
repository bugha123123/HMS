using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Service
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContextion _db;
        private readonly UserManager<User> _userManager;
        private readonly IDepartmentService _departmentService;
        private readonly IHospitalService _hospitalService;
        private readonly IDoctorService _doctorService;
        private readonly IEmailService _emailService;
        public AdminService(AppDbContextion db, UserManager<User> userManager, IDepartmentService departmentService, IHospitalService hospitalService, IDoctorService doctorService, IEmailService emailService)
        {
            _db = db;
            _userManager = userManager;
            _departmentService = departmentService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _emailService = emailService;
        }
        public async Task<List<Appointment>> Admin_GetAppointments(string? query, DepartmentType? DepartmentSpecialization, AppointmentStatus? status)
        {
            // Start with all appointments
            IQueryable<Appointment> queryable = _db.Appointments
                .Include(a => a.Patient)  // Includes the related Patient
                .Include(a => a.Doctor)  // Includes the related Doctor
                .ThenInclude(d => d.Department);  // Includes the related Department for the Doctor

            // Filter by query if it's not empty
            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(a => a.Patient.UserName.Contains(query) || a.Doctor.FullName.Contains(query));
            }

            // Filter by DepartmentSpecialization if it's provided
            if (DepartmentSpecialization.HasValue)
            {
                queryable = queryable.Where(a => a.Doctor.Department.Type == DepartmentSpecialization);
            }

            // Filter by status if it's provided
            if (status.HasValue)
            {
                queryable = queryable.Where(a => a.Status == status);
            }

            // Return the filtered list
            return await queryable.ToListAsync();
        }

 

        public async Task Admin_ScheduleAppointment(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes,int hospitalId)
        {
            var FoundPatient = await _userManager.FindByNameAsync(PatientUserName);

            var FoundDepartment = await _departmentService.GetDepartmentById(departmentId);

            var FoundHospital = await _hospitalService.GetHospitalById(hospitalId);

            var FoundDoctor = await _doctorService.GetDoctorById(DoctorId);

            if (FoundPatient is  null || FoundDepartment is null || FoundHospital is null || FoundDoctor is null)
                return;

            var Appointment = new Appointment()
            {
                Status = AppointmentStatus.Pending,
                AppointmentDate = date,
                AppointmentTime = time,
                Doctor = FoundDoctor,
                DoctorId = FoundDoctor.Id,
                HospitalName = FoundHospital.Name,
                MedicalHistories = FoundPatient.MedicalHistory,
                Patient = FoundPatient,
                PatientId = FoundPatient.Id,
             
                Reason = null,
                IsAdminScheduled = true,
                AdminNotes = Notes
               

            };

            await _db.Appointments.AddAsync(Appointment);
            await _db.SaveChangesAsync();

            var emailBody = $@"
        <h2>Your appointment has been scheduled by the Admin</h2>
        <p>Dear {FoundPatient.UserName},</p>
        <p>We are happy to inform you that your appointment has been successfully scheduled. Below are the details:</p>
        <ul>
            <li><strong>Doctor:</strong> Dr. {FoundDoctor.FullName}</li>
            <li><strong>Department:</strong> {FoundDepartment.Name}</li>
            <li><strong>Hospital:</strong> {FoundHospital.Name}</li>
            <li><strong>Appointment Date:</strong> {date.ToString("MMMM dd, yyyy")}</li>
            <li><strong>Appointment Time:</strong> {time.ToString("hh:mm tt")}</li>
            <li><strong>Notes:</strong> {Notes}</li>
        </ul>
        <p>If you have any questions, please feel free to contact us.</p>
        <p>Thank you for choosing our service.</p>
        <p>Best regards, <br> The Admin Team</p>";


            await _emailService.SendEmailAsync(FoundPatient.Email, "Your Appointment Has Been Scheduled",emailBody);





        }

        public async Task<List<User>> Admin_GetPatients()
        {
           return await _db.Users.ToListAsync();
        }

        public async Task<List<Doctor>> Admin_GetDoctors()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task<List<Department>> Admin_GetDepartments()
        {
            return await _db.Departments.ToListAsync();

        }

        public async Task<List<Appointment>> Admin_GetTodaysAppointments()
        {
            var today = DateTime.UtcNow.Date; //current day
            return await _db.Appointments
                .Where(a => a.AppointmentDate.Date == today)
                .ToListAsync();
        }

        public async Task<List<Appointment>> Admin_GetCompletedAppointments()
        {
            return await _db.Appointments
                .Where(a => a.Status == AppointmentStatus.Completed)
                .ToListAsync();
        }

        public async Task<List<Appointment>> Admin_GetPendingAppointments()
        {
            return await _db.Appointments
                .Where(a => a.Status == AppointmentStatus.Pending)
                .ToListAsync();
        }

        public async Task<List<Appointment>> Admin_GetCanceledAppointments()
        {
            return await _db.Appointments
                .Where(a => a.Status == AppointmentStatus.Cancelled)
                .ToListAsync();
        }
    }
}
