namespace HMS.Model
{
    public class Appointment
    {
        public string Id { get; set; }

        // Foreign Key to Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        // Foreign Key to Doctor
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
