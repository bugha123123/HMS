using System;
using System.Threading.Tasks;  // Assuming your DbContext is in this namespace
using HMS.Model;
using HMS.Interface;
using HMS.DB;
using Microsoft.EntityFrameworkCore;

public class NotificationService : INotificationService
{
    private readonly AppDbContextion _db;

    public NotificationService(AppDbContextion db)
    {
        _db = db;
    }

    //TODO
    public Task DismissNotification(int NotificationId)
    {
        throw new NotImplementedException();
    }

    public async Task<DoctorNotification> Doctor_GetNotificationById(int NotId)
    {
        return await _db.DoctorNotifications.Include(x => x.Appointment).ThenInclude(x => x.MedicalHistories).Include(x => x.patient).FirstOrDefaultAsync(x => x.Id == NotId);
    }
    
    // Method to save notification for any user (doctor, patient, admin, etc.)
    public async Task Doctor_SaveNotificationAsync(int doctorId, string message, NotificationType type, string UserId, User user,Appointment appointment, int appointmentId)
    {
        var notification = new DoctorNotification
        {
            Message = message,
            Type = type, 
            IsRead = false, 
            CreatedAt = DateTime.UtcNow,
            DoctorId = doctorId,
            patient = user,
            PatientId = UserId,
            Appointment = appointment,
            AppointmentId = appointmentId


        };

        // Add the notification to the database
       await  _db.DoctorNotifications.AddAsync(notification);
        await _db.SaveChangesAsync(); 
    }

 
}
