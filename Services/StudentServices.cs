using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
namespace StudentApp.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly DataContext _context;
        public StudentServices(DataContext context)
        {
            _context = context;
        }
        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student? GetStudentById(int studentId)
        {
            return _context.Students.Include(s => s.Department).Include(s => s.Rank).FirstOrDefault(s => s.Id == studentId);
        }
        public List<Student> GetStudents(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)){
                return _context.Students
                    .Include(s => s.Department)
                    .Include(s => s.Rank)
                    .ToList();
            }
            return _context.Students
                .Include(s => s.Department)
                .Include(s => s.Rank)
                .Where(s =>
                    s.Class.Contains(keyword) ||
                    s.Name.Contains(keyword) ||
                    s.Address.Contains(keyword)
                )
                .ToList();
        }
        public bool RemoveStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student == null) return false;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }
        public Student? UpdateStudent(Student student)
        {
            var existedStudent = GetStudentById(student.Id);
            if (existedStudent == null) return null;
            existedStudent.Class = student.Class;
            existedStudent.Name = student.Name;
            existedStudent.Address = student.Address;
            existedStudent.Age = student.Age;
            existedStudent.DepartmentId = student.DepartmentId;
            existedStudent.RankId = student.RankId;
            _context.SaveChanges();
            return existedStudent;
        }
    }
}
