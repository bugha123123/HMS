using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Doctor> GetDoctorById(int DoctorId)
        {
            return await _db.Doctors.FirstOrDefaultAsync(d => d.Id == DoctorId);
        }

        public async Task<Doctor> GetDoctorByName(string Name)
        {
            return await _db.Doctors.FirstOrDefaultAsync(d => d.FullName == Name);
        }
    }
}
