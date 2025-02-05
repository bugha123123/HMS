﻿using HMS.Model;

namespace HMS.Interface
{
    public interface IAdminService
    {
        Task<List<Appointment>> Admin_GetAppointments(string query, DepartmentType? DepartmentSpecialization, AppointmentStatus? status);

        Task Admin_ScheduleAppointment(string PatientUserName, int departmentId, int DoctorId, DateTime date, DateTime time, string Notes, int hospitalId);

        Task<List<User>> Admin_GetPatients();

        Task<List<Doctor>> Admin_GetDoctors();

        Task<List<Department>> Admin_GetDepartments();

        Task<List<Appointment>> Admin_GetTodaysAppointments();
        Task<List<Appointment>> Admin_GetCompletedAppointments();
        Task<List<Appointment>> Admin_GetPendingAppointments();
        Task<List<Appointment>> Admin_GetCanceledAppointments();
    }
}
