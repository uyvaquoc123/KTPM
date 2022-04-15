using StudentApp.Models;

namespace StudentApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int departmentId)
        {
            var department = GetDepartmentById(departmentId);
            if (department == null) return;
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public Department? GetDepartmentById(int departmentId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == departmentId);
            if (department == null) return null;
            return department;
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public void UpdateDepartment(Department department)
        {
            var currentDepartment = GetDepartmentById(department.Id);
            if (currentDepartment == null) return;
            currentDepartment.Name = department.Name;
            _context.SaveChanges();
        }
    }
}