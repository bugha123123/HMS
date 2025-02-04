using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContextion _db;

        public HospitalService(AppDbContextion db)
        {
            _db = db;
        }

        public async Task<List<Hospital>> GetAllHospitals()
        {
            return await _db.Hospitals.ToListAsync();
        }

        public async Task<Hospital> GetHospitalById(int Hospitalid)
        {
            return await _db.Hospitals.FirstOrDefaultAsync(h => h.Id == Hospitalid);
        }

        public async Task<Hospital> GetHospitalByName(string Hospitalname)
        {
            return await _db.Hospitals.Include(x => x.Doctors).FirstOrDefaultAsync(h => h.Name == Hospitalname);

        }
    }
}
