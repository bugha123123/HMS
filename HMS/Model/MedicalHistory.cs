using System.ComponentModel.DataAnnotations;

namespace HMS.Model
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; } 

        public string PatientId { get; set; }
        public User Patient { get; set; }

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        public string? Notes { get; set; }

        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
    }
}
