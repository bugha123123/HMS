using HMS.Model;

namespace HMS.Interface
{
    public interface IPatientService
    {
        Task BookAppointmentAsync(string DoctorFullName, DateTime AppointmentDate, DateTime Appointmenttime, string PhoneNumber, string HospitalName, string Reason);

        Task<List<MedicalHistory>> GetMedicalHistoryAsync();

        Task<List<User>> GetUsers();

        Task<List<User>> FilterUsers(string query, int page = 1, int pageSize = 5); 
    }
}
