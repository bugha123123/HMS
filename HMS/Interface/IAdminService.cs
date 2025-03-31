using HMS.DTO;
using HMS.Model;
using Microsoft.AspNetCore.Identity;

namespace HMS.Interface
{
    public interface IAdminService
    {
        Task<List<Appointment>> Admin_GetAppointments(string query, DepartmentType? DepartmentSpecialization, AppointmentStatus? status);

        Task Admin_ScheduleAppointment(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes, int hospitalId);

        Task<List<User>> Admin_GetPatients();

        Task<List<Doctor>> Admin_GetDoctors();

        Task<List<Department>> Admin_GetDepartments();

        Task<List<Appointment>> Admin_GetTodaysAppointments();
        Task<List<Appointment>> Admin_GetCompletedAppointments();
        Task<List<Appointment>> Admin_GetPendingAppointments();
        Task<List<Appointment>> Admin_GetCanceledAppointments();

        Task<List<DoctorApplication>> Admin_GetDoctorApplications();
        Task Admin_CancelAppointment(int AppointmentId);

        Task<List<User>> GetRecentPatients();

        Task<List<Appointment>> GetUpcomingAppointments();

        Task ApproveApplication(int ApplicationId);


        Task<DoctorApplication> GetApplicationById(int ApplicationId);

        Task RejectDoctorApplication(int ApplicationId);

        Task<Appointment> GetAppointmentById(int AppointmentId);

        Task<IdentityResult> AddNewPatient(string email, string contactNumber, int age,string gender);

        Task SendPasswordSetupEmail(string email, User user);

        Task DeletePatient(string PatientId);

        

    }
}
