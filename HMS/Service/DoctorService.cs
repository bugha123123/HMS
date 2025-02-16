using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContextion _db;
        private readonly IEmailService emailService;

        public DoctorService(AppDbContextion db, IEmailService emailService)
        {
            _db = db;
            this.emailService = emailService;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _db.Doctors.Include(x => x.DoctorApplication).ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int doctorId)
        {
            return await _db.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
        }

        public async Task<Doctor> GetDoctorByName(string name)
        {
            return await _db.Doctors.FirstOrDefaultAsync(d => d.FullName == name);
        }

        public async Task<List<Doctor>> GetAvailableDoctors()
        {
            return await _db.Doctors.Where(x => x.Status == DoctorStatus.Available).ToListAsync();
        }


        public async Task SaveDoctorApplicationAsync(DoctorApplication doctorApplication)
        {
            if (doctorApplication is null)
                return;

            // Set status to 0 (pending) by default
            doctorApplication.Status = DoctorApplication.ApplicationStatus.Pending;  

            // Check if the email already exists in the database
            var existingApplication = await _db.doctorApplications
                                                 .FirstOrDefaultAsync(d => d.Email == doctorApplication.Email);

            if (existingApplication is not null)
            {
                return;
            }

            string subject = "Doctor Application Received";
            string htmlBody = $"<p>Dear {doctorApplication.FirstName},</p>" +
                              "<p>Thank you for applying. Your application is under review.</p>" +
                              "<p>We will notify you once it has been processed.</p>" +
                              "<p>Best regards,<br>Hospital Management Team</p>";

            // Save the new doctor application to the database
            await _db.doctorApplications.AddAsync(doctorApplication);
            await _db.SaveChangesAsync();

            // Send email confirmation
            await emailService.SendEmailAsync(doctorApplication.Email, subject, htmlBody);
        }

        public async Task<List<Doctor>> FilterDoctors(string? query)
        {
            var doctors = _db.Doctors
                .Include(x => x.DoctorApplication)
                .Include(x => x.Appointments)
                .Where(d => d.FullName.Contains(query) || d.Specialization.Contains(query))
                .ToListAsync();

            return await doctors;
        }



        public async Task<List<Appointment>> FilterAppointment(DateTime? when, string? query)
        {
            var queryable = await _db.Appointments.Include(x => x.Patient).Include(x => x.Doctor).Include(x => x.MedicalHistories).ToListAsync();

            // If 'when' is provided, filter by the appointment date
            if (when.HasValue)
            {
                queryable = queryable.Where(x => x.AppointmentDate == when.Value.Date).ToList();
            }

            // If 'query' (username) is provided, filter by patient username
            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(x => x.Patient.UserName.Contains(query)).ToList();
            }

            // Execute the query and return the filtered list
            return  queryable.ToList();
        }


        public async Task<List<Appointment>> GetAppointments()
        {
            return await _db.Appointments.ToListAsync();   
        }

        public async Task Doctor_ScheduleAppointment(int AppointmentId)
        {
            var FoundAppointment = await GetAppointmentById(AppointmentId);

            if (FoundAppointment is null)
                return;

            FoundAppointment.Status = AppointmentStatus.Scheduled;



            var NotificationToDelete = await _db.DoctorNotifications.FirstOrDefaultAsync(x => x.AppointmentId == FoundAppointment.Id);

            if (NotificationToDelete is not null)
            {
                _db.DoctorNotifications.Remove(NotificationToDelete);
                await _db.SaveChangesAsync();
            }

            await _db.SaveChangesAsync();
            
            string subject = "Your Appointment Has Been Scheduled";
            string emailBody = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1'>
            <title>Appointment Scheduled</title>
            <style>
                body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                .container {{ max-width: 600px; margin: 20px auto; background: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }}
                .header {{ background: #4CAF50; color: white; text-align: center; padding: 15px; border-top-left-radius: 8px; border-top-right-radius: 8px; }}
                .content {{ padding: 20px; text-align: center; }}
                .btn {{ display: inline-block; background: #4CAF50; color: white; padding: 12px 20px; text-decoration: none; font-size: 16px; border-radius: 5px; margin-top: 20px; }}
                .footer {{ text-align: center; padding: 15px; font-size: 12px; color: #777; }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h2>Appointment Confirmed</h2>
                </div>
                <div class='content'>
                    <p>Dear <strong>{FoundAppointment.Patient.UserName}</strong>,</p>
                    <p>Your appointment with <strong>Dr. {FoundAppointment.Doctor.FullName}</strong> has been successfully scheduled.</p>
                    <p><strong>Date:</strong> {FoundAppointment.AppointmentDate:MMMM dd, yyyy}</p>
                    <p><strong>Time:</strong> {FoundAppointment.AppointmentTime}</p>
                    <p><strong>Location:</strong> {FoundAppointment.HospitalName}, {FoundAppointment.Doctor.Department.Name}</p>
                    <p>Please arrive 10 minutes before your scheduled time.</p>
                  <a href='https://localhost:7253/Doctor/appointmentdetails?appId={FoundAppointment.Id}&R=P' class='btn'>View Appointment</a>

                </div>
                <div class='footer'>
                    <p>If you have any questions, please contact us at <a href='mailto:support@example.com'>support@example.com</a></p>
                    <p>&copy; 2025 Your Healthcare Service</p>
                </div>
            </div>
        </body>
        </html>";

            // Send the email
            await emailService.SendEmailAsync(FoundAppointment.Patient.Email, subject, emailBody);
        }

        public async Task<Appointment> GetAppointmentById(int AppointmentId)
        {
            return await _db.Appointments.Include(x => x.Doctor).ThenInclude(x => x.Department).Include(x => x.Patient).ThenInclude(x => x.MedicalHistory).Include(x => x.Doctor.DoctorApplication).FirstOrDefaultAsync(x => x.Id == AppointmentId);
        }

        public async Task Doctor_ReScheduleAppointment(int AppointmentId, DateTime time, DateTime date, string reason)
        {
            var FoundAppointment = await GetAppointmentById(AppointmentId);
            if (FoundAppointment is null)
                return;

            // Update the appointment details
            FoundAppointment.AppointmentDate = date;
            FoundAppointment.Reason = reason;
            FoundAppointment.AppointmentTime = time;
            FoundAppointment.Status = AppointmentStatus.Rescheduled;
            FoundAppointment.DoctorNotes = reason;


            var NotificationToDelete = await _db.DoctorNotifications.FirstOrDefaultAsync(x => x.AppointmentId == FoundAppointment.Id);

            if (NotificationToDelete is not null)
            {
                _db.DoctorNotifications.Remove(NotificationToDelete);
                await _db.SaveChangesAsync();
            }

            // Save changes to the database
            await _db.SaveChangesAsync();

            // Create subject and body for the email
            string subject = "Appointment Rescheduled";
            string body = $@"
        <h2>Appointment Rescheduled</h2>
        <p>Dear {FoundAppointment.Patient.UserName},</p>
        <p>Your appointment has been rescheduled to the following details:</p>
        <p><strong>New Date:</strong> {FoundAppointment.AppointmentDate:dddd, MMMM dd, yyyy}</p>
        <p><strong>New Time:</strong> {FoundAppointment.AppointmentTime:h:mm tt}</p>
        <p><strong>Reason for Rescheduling:</strong> {reason}</p>
        <p>If you have any questions, please feel free to contact us.</p>
        <p>Thank you for your understanding.</p>
        <p>Best regards, <br>Your Hospital Team</p>
    ";

            // Send the rescheduled appointment email to the patient
            await emailService.SendEmailAsync(FoundAppointment.Patient.Email, subject, body);
        }

        public async Task<List<DoctorNotification>> GetAllDoctorNotifications()
        {
            return await _db.DoctorNotifications.ToListAsync();
        }

        public async Task SaveDoctorNote(int AppointmentId, string DoctorNote)
        {
           var FoundAppointment = await GetAppointmentById(AppointmentId);

            if (FoundAppointment is null)
                return;

            FoundAppointment.DoctorNotes = DoctorNote;

            await _db.SaveChangesAsync();


            //TODO Send notification to user that doctor added a note

        }

        public async Task CancelAppointment(int AppointmentId)
        {
            var AppointmentToDelete = await GetAppointmentById(AppointmentId);

            if (AppointmentToDelete is null)
                return;

            // Set related MedicalHistories' AppointmentId to null (disassociate from the appointment)
            foreach (var medicalHistory in AppointmentToDelete.MedicalHistories)
            {
                medicalHistory.AppointmentId = null;  // Disassociate by setting AppointmentId to null
            }

            var NotificationToDelete = await _db.DoctorNotifications.FirstOrDefaultAsync(x => x.AppointmentId == AppointmentToDelete.Id);

            if (NotificationToDelete is not null)
            {
                _db.DoctorNotifications.Remove(NotificationToDelete);
                await _db.SaveChangesAsync();
            }



            // Remove the appointment itself
            _db.Appointments.Remove(AppointmentToDelete);
            await _db.SaveChangesAsync();

            // Send cancellation email
            await emailService.SendEmailAsync(
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
    }
}
