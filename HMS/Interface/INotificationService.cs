using HMS.Model;

namespace HMS.Interface
{
    public interface INotificationService
    {
        Task SaveNotificationAsync(int doctorId, string message, NotificationType type, string UserId, User user, Appointment appointment, int appointmentId, RecipientRole role);

        Task<Notification> Doctor_GetNotificationById(int NotId);

        Task<Notification> Patient_GetNotificationById(int NotId);

        Task DismissNotification(int NotificationId);

        Task<List<Notification>> GetAllPatientNotifications();
    }
}
