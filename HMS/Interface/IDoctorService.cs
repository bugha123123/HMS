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

        // New method to filter doctors by query, department, and specialization
        Task<List<Doctor>> FilterDoctors(string? query, Department department);
    }
}
