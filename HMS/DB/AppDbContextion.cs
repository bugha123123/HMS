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
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DBSeeder.DBSeeder.SeedData(modelBuilder);
        }

    
    }
}
