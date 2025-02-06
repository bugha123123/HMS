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

        public DoctorService(AppDbContextion db)
        {
            _db = db;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _db.Doctors.ToListAsync();
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

            
            // Save the new doctor application to the database
            await _db.doctorApplications.AddAsync(doctorApplication);
            await _db.SaveChangesAsync();
        }


    }
}
