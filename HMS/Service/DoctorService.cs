﻿using HMS.DB;
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

        //TODO FIX THIS, SEARCH DOES NOT WORK
        public async Task<List<Doctor>> FilterDoctors(string? query, Department? department)
        {
            // Start with the queryable collection
            var doctors = _db.Doctors.AsQueryable();

            // Filter by department if specified
            if (department != null)
            {
                doctors = doctors.Where(d => d.Department == department);
            }
            
           
            if (!string.IsNullOrWhiteSpace(query))
            {
                var queryLower = query.ToLower();

                // Use EF.Functions.Like to do case-insensitive searches for the query
                doctors = doctors.Where(d =>
                    EF.Functions.Like(d.DoctorApplication.FirstName, $"%{queryLower}%") ||
                    EF.Functions.Like(d.Specialization, $"%{department}%") ||
                    EF.Functions.Like(d.DoctorApplication.LastName, $"%{queryLower}%")
                );
            }

            // Execute and return the list of filtered doctors
            return await doctors.ToListAsync();
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
            return await _db.Appointments.Include(x => x.Doctor).ThenInclude(x => x.Department).Include(x => x.Patient).Include(x => x.Doctor.DoctorApplication).FirstOrDefaultAsync(x => x.Id == AppointmentId);
        }
        //TODO
        public Task Doctor_ResScheduleAppointment(int AppointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
