using HMS.Model;

namespace HMS.Interface
{
    public interface IPatientService
    {
        Task BookAppointmentAsync(string DoctorFullName, DateTime AppointmentDate, DateTime Appointmenttime, string PhoneNumber, string HospitalName, string Reason);

        Task<List<MedicalHistory>> GetMedicalHistoryAsync();
    }
}
