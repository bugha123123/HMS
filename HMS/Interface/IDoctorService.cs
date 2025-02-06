using HMS.Model;

namespace HMS.Interface
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorById(int DoctorId);

        Task<Doctor> GetDoctorByName(string Name);

        Task<List<Doctor>> GetAllDoctors();

        Task<List<Doctor>> GetAvailableDoctors();

        Task SaveDoctorApplicationAsync(DoctorApplication doctorApplication);

    }
}
