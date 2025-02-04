namespace HMS.Model
{
    public class Doctor
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }



        public int? HospitalId { get; set; }
        // Foreign Key to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
