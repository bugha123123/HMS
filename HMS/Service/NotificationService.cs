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

    public async Task<Notification> Doctor_GetNotificationById(int NotId)
    {
        return await _db.Notifications.
            Include(x => x.Appointment).
            ThenInclude(x => x.MedicalHistories).
            Include(x => x.patient).
            Where(d => d.Role == RecipientRole.Doctor).
            FirstOrDefaultAsync(x => x.Id == NotId);
    }
    public async Task DismissNotification(int NotificationId)
    {
        var FoundNotification = await Doctor_GetNotificationById(NotificationId);

        if (FoundNotification is null)
            return;

        _db.Notifications.Remove(FoundNotification);
        await _db.SaveChangesAsync();
    }

    // Method to save notification for any user (doctor, patient, admin, etc.)
    public async Task SaveNotificationAsync(int doctorId, string message, NotificationType type, string UserId, User user,Appointment appointment, int appointmentId,RecipientRole role)
    {
        var notification = new Notification
        {
            Message = message,
            Type = type, 
            IsRead = false, 
            CreatedAt = DateTime.UtcNow,
            DoctorId = doctorId,
            patient = user,
            PatientId = UserId,
            Appointment = appointment,
            AppointmentId = appointmentId,
            Role = role
            
            
            



        };

        // Add the notification to the database
       await  _db.Notifications.AddAsync(notification);
        await _db.SaveChangesAsync(); 
    }

    public async Task<List<Notification>> GetAllPatientNotifications()
    {
        return await _db.Notifications.Include(x => x.patient).Include(x => x.Appointment).ThenInclude(x => x.Doctor).ToListAsync();
    }

    public async Task<Notification> Patient_GetNotificationById(int NotId)
    {
        return await _db.Notifications.
         Include(x => x.Appointment).
         ThenInclude(x => x.MedicalHistories).
         Include(x => x.patient).
         Where(d => d.Role == RecipientRole.Patient).
         FirstOrDefaultAsync(x => x.Id == NotId);
    }
}
