using Azure.Core;
using HMS.DB;
using HMS.DTO;
using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;

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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminService(AppDbContextion db, UserManager<User> userManager, IDepartmentService departmentService, IHospitalService hospitalService, IDoctorService doctorService, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _departmentService = departmentService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Appointment>> Admin_GetAppointments(string? query, DepartmentType? DepartmentSpecialization, AppointmentStatus? status)
        {
            // Start with all appointments
            IQueryable<Appointment> queryable = _db.Appointments
                .Include(a => a.Patient)  // Includes the related Patient
                .Include(a => a.Doctor)   // Includes the related Doctor
                .ThenInclude(d => d.Department); // Includes the related Department for the Doctor

            // Filter by query if it's not empty (case-insensitive search)
            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(a =>
                    a.Patient.UserName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    a.Doctor.FullName.Contains(query, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Filter by DepartmentSpecialization if it's provided
            if (DepartmentSpecialization.HasValue)
            {
                queryable = queryable.Where(a => a.Doctor.Department.Type == DepartmentSpecialization.Value);
            }

            // Filter by status if it's provided
            if (status.HasValue)
            {
                queryable = queryable.Where(a => a.Status == status.Value);
            }

            // Return the filtered list
            return await queryable.ToListAsync();
        }




        public async Task Admin_ScheduleAppointment(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes, int hospitalId)
        {
            var FoundPatient = await _userManager.FindByNameAsync(PatientUserName);

            var FoundDepartment = await _departmentService.GetDepartmentById(departmentId);

            var FoundHospital = await _hospitalService.GetHospitalById(hospitalId);

            var FoundDoctor = await _doctorService.GetDoctorById(DoctorId);

            if (FoundPatient is null || FoundDepartment is null || FoundHospital is null || FoundDoctor is null)
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


            await _emailService.SendEmailAsync(FoundPatient.Email, "Your Appointment Has Been Scheduled", emailBody);





        }

        public async Task<List<User>> Admin_GetPatients()
        {
            var allUsers = await _userManager.Users.ToListAsync(); // Get all users
            var patients = new List<User>();

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user); // Get roles for the user
                if (!roles.Contains("Doctor")) // Check if the user does not have 'Doctor' role
                {
                    patients.Add(user); // Add user to the list if not in 'Doctor' role
                }
            }

            return patients;
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

        public async Task Admin_CancelAppointment(int AppointmentId)
        {
            var AppointmentToDelete = await _db.Appointments
                                                .Include(u => u.Patient)
                                                .Include(a => a.MedicalHistories)
                                                .FirstOrDefaultAsync(a => a.Id == AppointmentId);

            if (AppointmentToDelete is null)
                return;

            // Set related MedicalHistories' AppointmentId to null (disassociate from the appointment)
            foreach (var medicalHistory in AppointmentToDelete.MedicalHistories)
            {
                medicalHistory.AppointmentId = null;  // Disassociate by setting AppointmentId to null
            }

            var NotificationToDelete = await _db.Notifications.FirstOrDefaultAsync(x => x.AppointmentId == AppointmentToDelete.Id);

            if (NotificationToDelete is not null)
            {
                 _db.Notifications.Remove(NotificationToDelete);
                await _db.SaveChangesAsync();
            }

          

            // Remove the appointment itself
            _db.Appointments.Remove(AppointmentToDelete);
            await _db.SaveChangesAsync();

            // Send cancellation email
            await _emailService.SendEmailAsync(
                AppointmentToDelete.Patient.Email,
                "Appointment Cancellation",
                @$"
        <body>
            <div class='container'>
                <h2>Appointment Cancellation</h2>
                <p>Dear {AppointmentToDelete.Patient.UserName},</p>
                <p>We regret to inform you that your appointment scheduled on <strong>{AppointmentToDelete.AppointmentDate}</strong> has been cancelled.</p>
                <p>If you have any questions, please contact our support team.</p>
                <p>Thank you for understanding.</p>
                <div class='footer'>Best Regards, <br> Your Clinic Team</div>
            </div>
        </body>
    "
            );
        }


        public async Task<List<User>> GetRecentPatients()
        {
            var recentPatients = await _db.Users
                                                 .Where(u => u.CreatedAt >= DateTime.Now.AddDays(-7))  // last seven days
                                                 .OrderByDescending(u => u.CreatedAt)
                                                 .ToListAsync();

            return recentPatients;
        }
        public async Task<List<Appointment>> GetUpcomingAppointments()
        {
            var upcomingAppointments = await _db.Appointments
                                                         .Include(u => u.Patient)
                                                         .Include(d => d.Doctor)
                                                        .Where(a => a.AppointmentDate > DateTime.Now && a.AppointmentDate <= DateTime.Now.AddDays(14))  // Appointments within the next 7 days
                                                        .OrderBy(a => a.AppointmentDate)
                                                        .ToListAsync();

            return upcomingAppointments;
        }

        public async Task<List<DoctorApplication>> Admin_GetDoctorApplications()
        {
            return await _db.doctorApplications.Where(x => x.Status == DoctorApplication.ApplicationStatus.Pending).ToListAsync();
        }
        public async Task<DoctorApplication> GetApplicationById(int ApplicationId)
        {
            return await _db.doctorApplications.FirstOrDefaultAsync(x => x.Id == ApplicationId);
        }
        public async Task ApproveApplication(int ApplicationId)
        {
            var FoundApplication = await GetApplicationById(ApplicationId);

            if (FoundApplication == null)
                return;

            var user = await _userManager.FindByEmailAsync(FoundApplication.Email);
            if (user != null)
            {
                // Check if the user is not already in the "Doctor" role
                if (!await _userManager.IsInRoleAsync(user, "Doctor"))
                {
                    // Remove the "Patient" role if assigned, and then assign the "Doctor" role
                    if (await _userManager.IsInRoleAsync(user, "Patient"))
                    {
                        await _userManager.RemoveFromRoleAsync(user, "Patient");
                    }

                    await _userManager.AddToRoleAsync(user, "Doctor");
                }
            }
            // Randomly assign fields
            var random = new Random();

            var departmentTypes = Enum.GetValues(typeof(DepartmentType)).Cast<DepartmentType>().ToArray();
            var hospitals = await _db.Hospitals.ToListAsync();  // List of all hospitals from the DB
            var departments = await _db.Departments.ToListAsync();  // List of all departments from the DB

            var randomDepartment = departments[random.Next(departments.Count)];
            var randomHospital = hospitals[random.Next(hospitals.Count)];

            var DoctorToApprove = new Doctor()
            {
                Specialization = FoundApplication.Specialization,
                Status = DoctorStatus.Available,
                Appointments = null,
                Department = randomDepartment,
                DepartmentId = randomDepartment.Id,
                DoctorApplication = FoundApplication,
                DoctorApplicationId = FoundApplication.Id,
                FullName = FoundApplication.FirstName + " " + FoundApplication.LastName,
                HospitalId = randomHospital.Id,
                PhoneNumber = "555-" + random.Next(1000000, 9999999),
                User = user,
                UserId = user.Id
            };

            await _db.Doctors.AddAsync(DoctorToApprove);

            // Update the application status to Approved
            FoundApplication.Status = DoctorApplication.ApplicationStatus.Approved;

            // Assign "Doctor" role to the user in Identity

            string subject = "Doctor Application Approved";
            string htmlBody = $"<p>Dear {FoundApplication.FirstName},</p>" +
                              "<p>Your application has been approved.</p>" +
                              "<p>Thank you for your patience.</p>" +
                              "<p>Best regards,<br>Hospital Management Team</p>";

            await _emailService.SendEmailAsync(FoundApplication.Email, subject, htmlBody);
            await _db.SaveChangesAsync();
        }



        public async Task RejectDoctorApplication(int ApplicationId)
        {
            var FoundApplication = await GetApplicationById(ApplicationId);

            if (FoundApplication == null)
                return;

            FoundApplication.Status = DoctorApplication.ApplicationStatus.Rejected;
            await _db.SaveChangesAsync();


        }

        public async Task<Appointment> GetAppointmentById(int AppointmentId)
        {
            return await _db.Appointments.Include(x => x.Patient).Include(x => x.Doctor).FirstOrDefaultAsync(a => a.Id == AppointmentId);
        }
        public async Task<IdentityResult> AddNewPatient(string email, string contactNumber, int age, string gender)
        {
            // Check if the user already exists
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email already registered" });
            }

            // Create a new Identity user without a password
            var user = new User
            {
                UserName = email,
                Email = email,
                Gender = gender,
                ContactNumber = contactNumber,
                Age = age
            };

            // Create the user without setting the password
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result; // Return error if creation fails
            }

            // Generate the password reset token
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Set the generated token in the user's SetPasswordToken property (if it exists in your User class)
            user.SetPasswordToken = resetToken;

            await _db.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, "PATIENT");

            // Send the password setup email
            await SendPasswordSetupEmail(user.Email, user);

            return IdentityResult.Success;
        }

        public async Task SendPasswordSetupEmail(string email, User user)
        {
            // Generate the password reset link manually by combining the parts
            var resetLink = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Admin/setpassword?email={email}&token={user.SetPasswordToken}";

            // Send the reset link to the user via email
            await _emailService.SendEmailAsync(user.Email, "Complete Your Registration",
                $"Hello, <br><br> You have been registered. Please <a href='{resetLink}'>click here</a> to set your password.");
        }

        public async Task DeletePatient(string PatientId)
        {
            var foundPatient = await _userManager.FindByIdAsync(PatientId);

            if (foundPatient == null)
            {
                // Patient not found, return early
                return;
            }

            // Find the related MedicalHistories and set their AppointmentId to null
            var medicalHistories = await _db.MedicalHistories
                .Include(x => x.Patient)
                .Where(mh => mh.Appointment.Patient.Id == foundPatient.Id)
                .ToListAsync();

            foreach (var history in medicalHistories)
            {
                history.AppointmentId = null;  // Remove the reference to the appointment
            }

          
            await _db.SaveChangesAsync();

           
            _db.Users.Remove(foundPatient);
            await _db.SaveChangesAsync();
        }

    }
}
