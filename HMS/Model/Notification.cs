namespace HMS.Model
{
    public enum NotificationType
    {
        AppointmentReminder,
        NewPatient,
        TestResult,
        SystemAlert,
        Other
    }

    public enum RecipientRole
    {
        Doctor,
        Patient,
        Admin
    }

    public class Notification
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        public string PatientId { get; set; }

        public User patient { get; set; }

        public Appointment? Appointment { get; set; }

        public int? AppointmentId { get; set; }

        public RecipientRole Role { get; set; } // New property to distinguish recipients
    }
}
