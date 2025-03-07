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

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<ChatMember> ChatMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DBSeeder.DBSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.MedicalHistories) 
                .WithOne(m => m.Appointment) 
                .HasForeignKey(m => m.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User) // A Doctor has one User
                .WithOne(u => u.Doctor) // A User has one Doctor (optional)
                .HasForeignKey<Doctor>(d => d.UserId) // Doctor holds the foreign key
                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Notification>()
    .HasOne(dn => dn.Appointment)
    .WithMany() // If Appointment has a navigation property for notifications, specify it here
    .HasForeignKey(dn => dn.AppointmentId)
    .OnDelete(DeleteBehavior.Restrict);

        }



    }
}
