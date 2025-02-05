using HMS.DB;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.DBSeeder
{
    public class DBSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
                    new Hospital
                    {
                        Id = 1,
                        Name = "San Francisco General Hospital",
                        Address = "1001 Potrero Ave",
                        City = "San Francisco",
                        State = "CA",
                        ZipCode = "94110",
                        PhoneNumber = "(415) 206-8000",
                        Website = "https://zuckerbergsanfranciscogeneral.org",
                        Latitude = 37.755634,
                        Longitude = -122.403748,
                        NumberOfBeds = 284,
                        Type = "General",
                        Ownership = "Public"
                    },
                    new Hospital
                    {
                        Id = 2,
                        Name = "Mayo Clinic",
                        Address = "200 1st St SW",
                        City = "Rochester",
                        State = "MN",
                        ZipCode = "55905",
                        PhoneNumber = "(507) 284-2511",
                        Website = "https://www.mayoclinic.org",
                        Latitude = 44.022705,
                        Longitude = -92.467369,
                        NumberOfBeds = 1_265,
                        Type = "Specialty",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 3,
                        Name = "Cleveland Clinic",
                        Address = "9500 Euclid Ave",
                        City = "Cleveland",
                        State = "OH",
                        ZipCode = "44195",
                        PhoneNumber = "(216) 444-2200",
                        Website = "https://my.clevelandclinic.org",
                        Latitude = 41.503201,
                        Longitude = -81.621277,
                        NumberOfBeds = 1_400,
                        Type = "Specialty",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 4,
                        Name = "Johns Hopkins Hospital",
                        Address = "1800 Orleans St",
                        City = "Baltimore",
                        State = "MD",
                        ZipCode = "21287",
                        PhoneNumber = "(410) 955-5000",
                        Website = "https://www.hopkinsmedicine.org",
                        Latitude = 39.296318,
                        Longitude = -76.592941,
                        NumberOfBeds = 1_000,
                        Type = "Academic Medical Center",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 5,
                        Name = "Massachusetts General Hospital",
                        Address = "55 Fruit St",
                        City = "Boston",
                        State = "MA",
                        ZipCode = "02114",
                        PhoneNumber = "(617) 726-2000",
                        Website = "https://www.massgeneral.org",
                        Latitude = 42.362400,
                        Longitude = -71.069206,
                        NumberOfBeds = 1_000,
                        Type = "Teaching Hospital",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 6,
                        Name = "Ronald Reagan UCLA Medical Center",
                        Address = "757 Westwood Plaza",
                        City = "Los Angeles",
                        State = "CA",
                        ZipCode = "90095",
                        PhoneNumber = "(310) 825-9111",
                        Website = "https://www.uclahealth.org",
                        Latitude = 34.066242,
                        Longitude = -118.445328,
                        NumberOfBeds = 520,
                        Type = "Academic Medical Center",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 7,
                        Name = "Houston Methodist Hospital",
                        Address = "6565 Fannin St",
                        City = "Houston",
                        State = "TX",
                        ZipCode = "77030",
                        PhoneNumber = "(713) 790-3311",
                        Website = "https://www.houstonmethodist.org",
                        Latitude = 29.709541,
                        Longitude = -95.398605,
                        NumberOfBeds = 1_000,
                        Type = "Teaching Hospital",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 8,
                        Name = "New York-Presbyterian Hospital",
                        Address = "525 East 68th Street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "10065",
                        PhoneNumber = "(212) 746-5454",
                        Website = "https://www.nyp.org",
                        Latitude = 40.710255,
                        Longitude = -74.005058,
                        NumberOfBeds = 2_600,
                        Type = "Teaching Hospital",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 9,
                        Name = "Cedars-Sinai Medical Center",
                        Address = "8700 Beverly Blvd",
                        City = "Los Angeles",
                        State = "CA",
                        ZipCode = "90048",
                        PhoneNumber = "(310) 423-3277",
                        Website = "https://www.cedars-sinai.org",
                        Latitude = 34.069206,
                        Longitude = -118.377000,
                        NumberOfBeds = 886,
                        Type = "Teaching Hospital",
                        Ownership = "Non-profit"
                    },
                    new Hospital
                    {
                        Id = 10,
                        Name = "Mount Sinai Hospital",
                        Address = "1 Gustave L. Levy Place",
                        City = "New York",
                        State = "NY",
                        ZipCode = "10029",
                        PhoneNumber = "(212) 241-6500",
                        Website = "https://www.mountsinai.org",
                        Latitude = 40.790276,
                        Longitude = -73.952646,
                        NumberOfBeds = 1_171,
                        Type = "Teaching Hospital",
                        Ownership = "Non-profit"
                    }
                );

            modelBuilder.Entity<Department>().HasData(
      new Department { Id = 1, Name = "Emergency Medicine", HospitalId = 1, Type = DepartmentType.EmergencyMedicine },
      new Department { Id = 2, Name = "General Medicine", HospitalId = 1, Type = DepartmentType.GeneralMedicine },
      new Department { Id = 3, Name = "Surgery", HospitalId = 1, Type = DepartmentType.Surgery },
      new Department { Id = 4, Name = "Pediatrics", HospitalId = 1, Type = DepartmentType.Pediatrics },
      new Department { Id = 5, Name = "Obstetrics and Gynecology", HospitalId = 1, Type = DepartmentType.ObstetricsGynecology },
      new Department { Id = 6, Name = "Orthopedic Surgery", HospitalId = 1, Type = DepartmentType.OrthopedicSurgery },
      new Department { Id = 7, Name = "Neurology", HospitalId = 1, Type = DepartmentType.Neurology },
      new Department { Id = 8, Name = "Cardiology", HospitalId = 1, Type = DepartmentType.Cardiology },
      new Department { Id = 9, Name = "Psychiatry", HospitalId = 1, Type = DepartmentType.Psychiatry },
      new Department { Id = 10, Name = "Radiology", HospitalId = 1, Type = DepartmentType.Radiology },

      new Department { Id = 11, Name = "Cardiovascular Medicine", HospitalId = 2, Type = DepartmentType.CardiovascularMedicine },
      new Department { Id = 12, Name = "Neurology", HospitalId = 2, Type = DepartmentType.Neurology },
      new Department { Id = 13, Name = "Orthopedic Surgery", HospitalId = 2, Type = DepartmentType.OrthopedicSurgery },
      new Department { Id = 14, Name = "Gastroenterology and Hepatology", HospitalId = 2, Type = DepartmentType.GastroenterologyHepatology },
      new Department { Id = 15, Name = "Endocrinology", HospitalId = 2, Type = DepartmentType.Endocrinology },
      new Department { Id = 16, Name = "Oncology", HospitalId = 2, Type = DepartmentType.Oncology },
      new Department { Id = 17, Name = "Pulmonary Medicine", HospitalId = 2, Type = DepartmentType.PulmonaryMedicine },
      new Department { Id = 18, Name = "Nephrology and Hypertension", HospitalId = 2, Type = DepartmentType.NephrologyHypertension },
      new Department { Id = 19, Name = "Rheumatology", HospitalId = 2, Type = DepartmentType.Rheumatology },
      new Department { Id = 20, Name = "Dermatology", HospitalId = 2, Type = DepartmentType.Dermatology }
  );



            modelBuilder.Entity<Doctor>().HasData(
                // Doctors at San Francisco General Hospital
                new Doctor { Id = 1, FullName = "Dr. John Doe", Specialization = "Emergency Medicine", PhoneNumber = "(415) 206-8000", DepartmentId = 1, HospitalId = 1 },
                new Doctor { Id = 2, FullName = "Dr. Jane Smith", Specialization = "General Medicine", PhoneNumber = "(415) 206-8001", DepartmentId = 2, HospitalId = 1 },
                new Doctor { Id = 3, FullName = "Dr. Emily Johnson", Specialization = "Surgery", PhoneNumber = "(415) 206-8002", DepartmentId = 3, HospitalId = 1 },
                new Doctor { Id = 4, FullName = "Dr. Mark Brown", Specialization = "Pediatrics", PhoneNumber = "(415) 206-8003", DepartmentId = 4, HospitalId = 1 },
                new Doctor { Id = 5, FullName = "Dr. Sarah Lee", Specialization = "Obstetrics and Gynecology", PhoneNumber = "(415) 206-8004", DepartmentId = 5, HospitalId = 1 },
                new Doctor { Id = 6, FullName = "Dr. Michael Wang", Specialization = "Orthopedic Surgery", PhoneNumber = "(415) 206-8005", DepartmentId = 6, HospitalId = 1 },

                // Doctors at Mayo Clinic
                new Doctor { Id = 7, FullName = "Dr. William Harris", Specialization = "Cardiovascular Medicine", PhoneNumber = "(507) 284-2511", DepartmentId = 8, HospitalId = 2 },
                new Doctor { Id = 8, FullName = "Dr. Olivia White", Specialization = "Neurology", PhoneNumber = "(507) 284-2512", DepartmentId = 7, HospitalId = 2 },
                new Doctor { Id = 9, FullName = "Dr. David Green", Specialization = "Orthopedic Surgery", PhoneNumber = "(507) 284-2513", DepartmentId = 13, HospitalId = 2 },
                new Doctor { Id = 10, FullName = "Dr. Isabella Adams", Specialization = "Gastroenterology and Hepatology", PhoneNumber = "(507) 284-2514", DepartmentId = 14, HospitalId = 2 },
                new Doctor { Id = 11, FullName = "Dr. Joseph Clark", Specialization = "Endocrinology", PhoneNumber = "(507) 284-2515", DepartmentId = 15, HospitalId = 2 },

                // Doctors at Cleveland Clinic
                new Doctor { Id = 12, FullName = "Dr. Thomas Scott", Specialization = "Heart, Vascular & Thoracic Institute", PhoneNumber = "(216) 444-2200", DepartmentId = 8, HospitalId = 3 },
                new Doctor { Id = 13, FullName = "Dr. Grace Martinez", Specialization = "Neurological Institute", PhoneNumber = "(216) 444-2201", DepartmentId = 9, HospitalId = 3 },
                new Doctor { Id = 14, FullName = "Dr. Ethan Robinson", Specialization = "Orthopaedic & Rheumatologic Institute", PhoneNumber = "(216) 444-2202", DepartmentId = 10, HospitalId = 3 },
                new Doctor { Id = 15, FullName = "Dr. Natalie Clark", Specialization = "Digestive Disease & Surgery Institute", PhoneNumber = "(216) 444-2203", DepartmentId = 9, HospitalId = 3 },
                new Doctor { Id = 16, FullName = "Dr. Henry Lewis", Specialization = "Cancer Center / Taussig Cancer Institute", PhoneNumber = "(216) 444-2204", DepartmentId = 8, HospitalId = 3 },

                // Doctors at Johns Hopkins Hospital
                new Doctor { Id = 17, FullName = "Dr. Alice Evans", Specialization = "Cardiology", PhoneNumber = "(410) 955-5000", DepartmentId = 8, HospitalId = 4 },
                new Doctor { Id = 18, FullName = "Dr. Robert King", Specialization = "Neurology", PhoneNumber = "(410) 955-5001", DepartmentId = 7, HospitalId = 4 },
                new Doctor { Id = 19, FullName = "Dr. Lily Moore", Specialization = "Orthopaedic Surgery", PhoneNumber = "(410) 955-5002", DepartmentId = 13, HospitalId = 4 },
                new Doctor { Id = 20, FullName = "Dr. Michael Taylor", Specialization = "Hematology", PhoneNumber = "(410) 955-5003", DepartmentId = 8, HospitalId = 4 },

                // Doctors at Massachusetts General Hospital
                new Doctor { Id = 21, FullName = "Dr. Ava Harris", Specialization = "Cardiology", PhoneNumber = "(617) 726-2000", DepartmentId = 8, HospitalId = 5 },
                new Doctor { Id = 22, FullName = "Dr. James Hall", Specialization = "Neurology", PhoneNumber = "(617) 726-2001", DepartmentId = 7, HospitalId = 5 },
                new Doctor { Id = 23, FullName = "Dr. Mia Young", Specialization = "Gastroenterology", PhoneNumber = "(617) 726-2002", DepartmentId = 13, HospitalId = 5 },
                new Doctor { Id = 24, FullName = "Dr. Ethan Lopez", Specialization = "Orthopaedic Surgery", PhoneNumber = "(617) 726-2003", DepartmentId = 10, HospitalId = 5 },
                new Doctor { Id = 25, FullName = "Dr. Lucas Martin", Specialization = "Oncology", PhoneNumber = "(617) 726-2004", DepartmentId = 8, HospitalId = 5 },

                // Doctors at Ronald Reagan UCLA Medical Center
                new Doctor { Id = 26, FullName = "Dr. Julia Ross", Specialization = "Cardiology", PhoneNumber = "(310) 825-9111", DepartmentId = 8, HospitalId = 6 },
                new Doctor { Id = 27, FullName = "Dr. Robert Williams", Specialization = "Neurology", PhoneNumber = "(310) 825-9112", DepartmentId = 7, HospitalId = 6 },
                new Doctor { Id = 28, FullName = "Dr. Samantha Bennett", Specialization = "Gastroenterology", PhoneNumber = "(310) 825-9113", DepartmentId = 13, HospitalId = 6 },
                new Doctor { Id = 29, FullName = "Dr. James White", Specialization = "Orthopaedic Surgery", PhoneNumber = "(310) 825-9114", DepartmentId = 10, HospitalId = 6 },

                // Doctors at Houston Methodist Hospital
                new Doctor { Id = 30, FullName = "Dr. Elizabeth Wright", Specialization = "Cardiology", PhoneNumber = "(713) 790-3311", DepartmentId = 8, HospitalId = 7 },
                new Doctor { Id = 31, FullName = "Dr. Charles Moore", Specialization = "Neurology", PhoneNumber = "(713) 790-3312", DepartmentId = 7, HospitalId = 7 },
                new Doctor { Id = 32, FullName = "Dr. Rachel Scott", Specialization = "Orthopaedic Surgery", PhoneNumber = "(713) 790-3313", DepartmentId = 10, HospitalId = 7 },

                // Doctors at New York-Presbyterian Hospital
                new Doctor { Id = 33, FullName = "Dr. Olivia Anderson", Specialization = "Cardiology", PhoneNumber = "(212) 746-5454", DepartmentId = 8, HospitalId = 8 },
                new Doctor { Id = 34, FullName = "Dr. Kevin Parker", Specialization = "Neurology", PhoneNumber = "(212) 746-5455", DepartmentId = 7, HospitalId = 8 },
                new Doctor { Id = 35, FullName = "Dr. Susan Moore", Specialization = "Orthopaedic Surgery", PhoneNumber = "(212) 746-5456", DepartmentId = 10, HospitalId = 8 },

                // Doctors at Cedars-Sinai Medical Center
                new Doctor { Id = 36, FullName = "Dr. Daniel Brown", Specialization = "Cardiology", PhoneNumber = "(310) 423-3277", DepartmentId = 8, HospitalId = 9 },
                new Doctor { Id = 37, FullName = "Dr. Anna Robinson", Specialization = "Neurology", PhoneNumber = "(310) 423-3278", DepartmentId = 7, HospitalId = 9 },
                new Doctor { Id = 38, FullName = "Dr. Emily Harris", Specialization = "Orthopaedic Surgery", PhoneNumber = "(310) 423-3279", DepartmentId = 10, HospitalId = 9 },

                // Doctors at Mount Sinai Hospital
                new Doctor { Id = 39, FullName = "Dr. David Carter", Specialization = "Cardiology", PhoneNumber = "(212) 241-6500", DepartmentId = 8, HospitalId = 10 },
                new Doctor { Id = 40, FullName = "Dr. Lily Baker", Specialization = "Neurology", PhoneNumber = "(212) 241-6501", DepartmentId = 7, HospitalId = 10 },
                new Doctor { Id = 41, FullName = "Dr. John Davis", Specialization = "Orthopaedic Surgery", PhoneNumber = "(212) 241-6502", DepartmentId = 10, HospitalId = 10 }
            );


        }
    }
}


      
