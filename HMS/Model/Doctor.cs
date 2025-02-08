namespace HMS.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }

        public int? HospitalId { get; set; }  // Optional: You can link this to a hospital
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Adding the foreign key for DoctorApplication
        public int? DoctorApplicationId { get; set; } // Foreign key reference to DoctorApplication
        public DoctorApplication DoctorApplication { get; set; }  // Navigation property

        public ICollection<Appointment> Appointments { get; set; }

        public DoctorStatus Status { get; set; } = DoctorStatus.Available;

        // Navigation property to User
        public string? UserId { get; set; }  // Foreign key for the associated User
        public User? User { get; set; }  // Navigation property for the associated User
    }

    public enum DoctorStatus
    {
        Available,
        OnLeave,
        Busy,
        Unavailable
    }
}
