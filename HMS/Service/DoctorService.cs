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

            await emailService.SendEmailAsync(doctorApplication.Email, subject, htmlBody);
            // Save the new doctor application to the database
            await _db.doctorApplications.AddAsync(doctorApplication);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Doctor>> FilterDoctors(string? query, Department? department)
        {
            var doctors = _db.Doctors.AsQueryable();

            // Filter by department if specified
            if (department is null)
            {
                doctors = doctors.Where(d => d.Department == department);
            }

            // Apply search query if provided
            if (!string.IsNullOrWhiteSpace(query))
            {
                var queryLower = query.ToLower();  // Convert the query to lower case for case-insensitive comparison

                doctors = doctors.Where(d =>
                    EF.Functions.Like(d.DoctorApplication.FirstName.ToLower(), $"%{queryLower}%") ||
                    EF.Functions.Like(d.Specialization.ToLower(), $"%{queryLower}%") ||
                    EF.Functions.Like(d.DoctorApplication.LastName.ToLower(), $"%{queryLower}%")
                );
            }

            return await doctors.ToListAsync();
        }





    }
}
