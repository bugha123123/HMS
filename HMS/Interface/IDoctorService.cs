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
        Task<List<Doctor>> FilterDoctors(string? query);

        Task<List<Appointment>> FilterAppointment(DateTime? when,string? query);

        Task<List<Appointment>> GetAppointments();

        Task Doctor_ScheduleAppointment(int AppointmentId);
        Task Doctor_ReScheduleAppointment(int AppointmentId, DateTime time, DateTime date, string reason);
        Task<Appointment> GetAppointmentById(int AppointmentId);

        Task<List<DoctorNotification>> GetAllDoctorNotifications();

        Task SaveDoctorNote(int AppointmentId,string DoctorNote);

        Task CancelAppointment(int AppointmentId);





    }
}
