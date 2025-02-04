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
    }
}
