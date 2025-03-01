using HMS.DTO;
using HMS.Model;
using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;

namespace HMS.Interface
{
    public interface IPatientService
    {
        Task BookAppointmentAsync(string DoctorFullName, DateTime AppointmentDate, DateTime Appointmenttime, string PhoneNumber, string HospitalName, string Reason);

        Task<List<MedicalHistory>> GetMedicalHistoryAsync();

        Task<List<User>> GetUsers();

        Task<List<User>> FilterUsers(string query, int page = 1, int pageSize = 5);

        Task<IdentityResult> SetPassword(string email,string newPassword);

        Task MarkNotificationAsRead(int notificationId);


        Task EditProfile(IFormFile profilePicture);

        Task<IdentityResult> ChangePassword(string oldPassword, string newPassword);
    }
}
