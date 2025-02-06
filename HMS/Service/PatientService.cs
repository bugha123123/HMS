using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.Service
{
    public class PatientService : IPatientService
    {
        private readonly IAuthService _authService;
        private readonly IDoctorService _doctorService;
        private readonly AppDbContextion _db;
        private readonly IHospitalService _hospitalService;
        private readonly IEmailService _emailService;

        public PatientService(IAuthService authService, IDoctorService octorService, AppDbContextion db, IHospitalService hospitalService, IEmailService emailService)
        {
            _authService = authService;
            _doctorService = octorService;
            _db = db;
            _hospitalService = hospitalService;
            _emailService = emailService;
        }

        public async Task BookAppointmentAsync(string DoctorFullName,DateTime AppointmentDate,DateTime Appointmenttime, string PhoneNumber, string HospitalName, string Reason)
        {
            var LoggedInPatient = await _authService.GetLoggedInUserAsync();

            var FoundDoctor = await _doctorService.GetDoctorByName(DoctorFullName);

            var FoundHospital = await _hospitalService.GetHospitalByName(HospitalName);

            if (LoggedInPatient is null || FoundDoctor is null || FoundHospital is null)
                return;

            var Appointment = new Appointment()
            {
                AppointmentDate = AppointmentDate,
                AppointmentTime = Appointmenttime,
                Doctor = FoundDoctor,
                DoctorId = FoundDoctor.Id,
                Patient = LoggedInPatient,
                PatientId = LoggedInPatient.Id,
                Status = AppointmentStatus.Pending,
                PhoneNumber = PhoneNumber,
                HospitalName = FoundHospital.Name,
                Reason = Reason,
                IsAdminScheduled = false,
                

            };

      

            // Add to the MedicalHistory table
            

            await _db.Appointments.AddAsync(Appointment);
            

            var medicalHistory = new MedicalHistory
            {
                PatientId = LoggedInPatient.Id,
                AppointmentId = Appointment.Id,
                Appointment = Appointment
                
            };

           await  _db.MedicalHistories.AddAsync(medicalHistory);

            // Save changes
            await _db.SaveChangesAsync();

            string HTML_BODY = $@"
    <div class='max-w-2xl mx-auto my-8 bg-white rounded-lg shadow-md overflow-hidden'>
        <div class='bg-blue-600 text-white py-4 px-6'>
            <h1 class='text-2xl font-bold'>Appointment Confirmation</h1>
        </div>
        <div class='p-6'>
            <p class='mb-4'>Dear {LoggedInPatient.UserName},</p>
            <p class='mb-4'>Your appointment has been successfully booked. Here are the details:</p>
            
            <div class='bg-gray-100 rounded-lg p-4 mb-6'>
                <h2 class='text-xl font-semibold mb-2'>Appointment Information</h2>
                <p><strong>Date:</strong> {AppointmentDate }</p>
                <p><strong>Time:</strong> {Appointmenttime }</p>
                <p><strong>Location:</strong> [Clinic/Hospital Name]</p>
                <p>{FoundHospital.Address}</p>
            </div>
            
            <div class='bg-gray-100 rounded-lg p-4 mb-6'>
                <h2 class='text-xl font-semibold mb-2'>Doctor Details</h2>
                <p><strong>Name:</strong> Dr. {FoundDoctor.FullName}</p>
                <p><strong>Specialization:</strong> {FoundDoctor.Specialization}</p>
            </div>
            
            <p class='mb-4'>Please arrive 15 minutes before your scheduled appointment time. If you need to reschedule or cancel, please contact us at least 24 hours in advance.</p>
            
            <p class='mb-4'>If you have any questions or concerns, please don't hesitate to contact us.</p>
            
            <p class='mb-2'>Best regards,</p>
            <p>[Clinic/Hospital Name] Team</p>
        </div>
        <div class='bg-gray-200 px-6 py-4 text-sm text-gray-700'>
            <p>This is an automated email. Please do not reply to this message.</p>
        </div>
    </div>";


            await _emailService.SendEmailAsync(LoggedInPatient.Email,"Appointment", HTML_BODY);
        }

        public async Task<List<User>> FilterUsers(string query, int page = 1, int pageSize = 5)
        {
            var LoggedInUser = await _authService.GetLoggedInUserAsync();
            if (LoggedInUser is null)
                return new List<User>();

            var queryable = _db.Users.Where(u => u.Id != LoggedInUser.Id).AsQueryable();

            // If the query is not null or empty, filter by UserName or Email
            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(u => u.UserName.Contains(query) || u.Email.Contains(query));
            }

            // Implement pagination
            var skip = (page - 1) * pageSize;
            var users = await queryable.Skip(skip).Take(pageSize).ToListAsync();

            return users;
        }



        public async Task<List<MedicalHistory>> GetMedicalHistoryAsync()
        {
            var LoggedInPatient = await _authService.GetLoggedInUserAsync();

            if (LoggedInPatient is null)
                return new List<MedicalHistory>();


            return await _db.MedicalHistories.Include(x => x.Patient).Include(x => x.Appointment).ThenInclude(x => x.Doctor).Where(m => m.Patient.Id == LoggedInPatient.Id).ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
           
            return await _db.Users.ToListAsync();
        }
    }
}
