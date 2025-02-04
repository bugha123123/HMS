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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DBSeeder.DBSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<MedicalHistory>()
                    .HasOne(mh => mh.Patient)
                    .WithMany(p => p.MedicalHistory) // Make sure the Patient has the collection of MedicalHistories
                    .HasForeignKey(mh => mh.PatientId)
                    .OnDelete(DeleteBehavior.Restrict); // No cascade delete for PatientId

            // Prevent cascade delete for AppointmentId
          
        }

    
    }
}
