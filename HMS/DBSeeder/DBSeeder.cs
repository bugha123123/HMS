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
      new Department { Id = 2, Name = "General Medicine", HospitalId = 2, Type = DepartmentType.GeneralMedicine },
      new Department { Id = 3, Name = "Surgery", HospitalId = 3, Type = DepartmentType.Surgery },
      new Department { Id = 4, Name = "Pediatrics", HospitalId = 4, Type = DepartmentType.Pediatrics },
      new Department { Id = 5, Name = "Obstetrics and Gynecology", HospitalId = 5, Type = DepartmentType.ObstetricsGynecology },
      new Department { Id = 6, Name = "Orthopedic Surgery", HospitalId = 6, Type = DepartmentType.OrthopedicSurgery },
      new Department { Id = 7, Name = "Neurology", HospitalId = 7, Type = DepartmentType.Neurology },
      new Department { Id = 8, Name = "Cardiology", HospitalId = 8, Type = DepartmentType.Cardiology },
      new Department { Id = 9, Name = "Psychiatry", HospitalId = 9, Type = DepartmentType.Psychiatry },
      new Department { Id = 10, Name = "Radiology", HospitalId = 10, Type = DepartmentType.Radiology }

      
  );



          


        }
    }
}


      
