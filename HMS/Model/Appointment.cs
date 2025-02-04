using System.ComponentModel.DataAnnotations;

namespace HMS.Model
{
    public enum AppointmentStatus
        {
            Scheduled,
            Completed,
            Cancelled,
            Rescheduled,
            Pending
        }
    public class Appointment
    {

     

        [Key]
        public int Id { get; set; }

        // Foreign Key to Patient
        public string PatientId { get; set; }
        public User Patient { get; set; }

        // Foreign Key to Doctor
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        // Using Enum for Status
        public AppointmentStatus Status { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 characters.")]
        [RegularExpression(@"^\+?[0-9\s\-\(\)]{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }


        public string HospitalName { get; set; }

        public string Reason { get; set; }

        public ICollection<MedicalHistory> MedicalHistories { get; set; }

    }
}
