namespace HMS.Model
{
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key to Hospital
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        // Navigation property to doctors
        public ICollection<Doctor> Doctors { get; set; }
    }
}
