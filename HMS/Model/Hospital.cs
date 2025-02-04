namespace HMS.Model
{
  
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NumberOfBeds { get; set; }
        public string Type { get; set; }
        public string Ownership { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
