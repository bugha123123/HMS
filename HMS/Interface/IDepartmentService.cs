using HMS.Model;

namespace HMS.Interface
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int Id);
    }
}
