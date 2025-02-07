using HMS.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.DB
{
    public class AppDbContextion : IdentityDbContext<User>
    {
        public AppDbContextion(DbContextOptions<AppDbContextion> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<MedicalHistory> MedicalHistories { get; set; }


        public DbSet<DoctorApplication> doctorApplications  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DBSeeder.DBSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<MedicalHistory>()
                    .HasOne(mh => mh.Patient)
                    .WithMany(p => p.MedicalHistory) // Make sure the Patient has the collection of MedicalHistories
                    .HasForeignKey(mh => mh.PatientId)
                    .OnDelete(DeleteBehavior.Restrict); // No cascade delete for PatientId

           

            


            modelBuilder.Entity<Doctor>()
            .HasOne(d => d.User)  // A Doctor has one User
            .WithOne(u => u.Doctor)  // A User has one Doctor (optional)
            .HasForeignKey<Doctor>(d => d.UserId)  // Doctor holds the foreign key
            .OnDelete(DeleteBehavior.SetNull);  // Optional: set to null if Doctor is deleted

            // Alternatively, configure the User entity's relationship to Doctor
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)  // A User has one Doctor
                .WithOne(d => d.User)   // A Doctor has one User
                .HasForeignKey<User>(u => u.DoctorId)  // User holds the foreign key (optional)
                .OnDelete(DeleteBehavior.SetNull);

        }

    
    }
}
