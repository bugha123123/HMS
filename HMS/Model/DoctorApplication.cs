using System.ComponentModel.DataAnnotations;

namespace HMS.Model
{
    public class DoctorApplication
    {
        public int Id { get; set; }

        // Personal Information
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [GmailDomain(ErrorMessage = "Email must end with '@gmail.com'")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        // Professional Information
        [Required(ErrorMessage = "Medical license number is required")]
        public string MedicalLicenseNumber { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Years of experience is required")]
        [Range(0, 100, ErrorMessage = "Years of experience must be between 0 and 100")]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Practice description is required")]
        [StringLength(500, ErrorMessage = "Practice description cannot exceed 500 characters")]
        public string PracticeDescription { get; set; }

        // Education
        [Required(ErrorMessage = "Medical school is required")]
        public string MedicalSchool { get; set; }

        [Required(ErrorMessage = "Degree/Certification is required")]
        public string DegreeOrCertification { get; set; }

        [Required(ErrorMessage = "Graduation year is required")]
        [Range(1950, 2024, ErrorMessage = "Please enter a valid graduation year")]
        public int GraduationYear { get; set; }

        [Required(ErrorMessage = "Board certification is required")]
        public string BoardCertification { get; set; }

        // Hospital Affiliations
        [Required(ErrorMessage = "Primary hospital affiliation is required")]
        public string PrimaryHospitalAffiliation { get; set; }

        public string? SecondaryHospitalAffiliation { get; set; } // Optional



        public ApplicationStatus? Status { get; set; } = ApplicationStatus.Pending;

        public enum ApplicationStatus
        {
            Pending,   // Default when a doctor applies
            Approved,  // When the admin approves the application
            Rejected   // If the application is rejected
        }
    }
}
