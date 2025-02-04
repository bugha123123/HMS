namespace HMS.Model
{
    public class Patient
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string MedicalHistory { get; set; }
        public string ContactNumber { get; set; }

        // Navigation property to appointments
        public ICollection<Appointment> Appointments { get; set; }
    }
}
