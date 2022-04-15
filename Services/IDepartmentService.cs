using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Models;

namespace StudentApp.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();

        Department? GetDepartmentById (int DepartmentId);

        void AddDepartment (Department department);

        void UpdateDepartment (Department department);

        void DeleteDepartment (int DepartmentId);
    }
}