using HMS.Model;

namespace HMS.Interface
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int Id);

        Task<List<Department>> GetDepartments();

        Task<List<Department>> GetDepartmentOverviewAsync();
    }
}
