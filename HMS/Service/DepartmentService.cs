using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContextion _db;

        public DepartmentService(AppDbContextion db)
        {
            _db = db;
        }

        public async Task<Department> GetDepartmentById(int Id)
        {
            return await _db.Departments.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _db.Departments.ToListAsync();
        }
    }
}
