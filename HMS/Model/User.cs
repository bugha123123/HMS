﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Model
{
    public class User : IdentityUser
    {
        public List<MedicalHistory>? MedicalHistory { get; set; }
        public string? ContactNumber { get; set; }

        // Navigation property to appointments
        public ICollection<Appointment>? Appointments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int Age { get; set; }

        public string Gender { get; set; }

        // Foreign key for Doctor, allowing User to be linked to a Doctor if necessary
        public int? DoctorId { get; set; }  // Nullable DoctorId
        public Doctor? Doctor { get; set; }

        public string? SetPasswordToken { get; set; }


        public byte[]? ProfilePicture { get; set; }

        public UserStatus Status { get; set; } = UserStatus.Active;

        // allows doctor to access his medical data

        public MedicalAccessStatus AllowMedicalAccess { get; set; } = MedicalAccessStatus.Granted;
        public enum UserStatus
        {
            Active,
            Discharged,
            Critical
        }

        public enum MedicalAccessStatus
        {
            Denied = 0,
            Granted = 1
        }


    }
}
