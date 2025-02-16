using HMS.Model;

namespace HMS.Interface
{
    public interface INotificationService
    {
        Task Doctor_SaveNotificationAsync(int doctorId, string message, NotificationType type, string UserId, User user, Appointment appointment, int appointmentId);

        Task<DoctorNotification> Doctor_GetNotificationById(int NotId);

        Task DismissNotification(int NotificationId);
    }
}
