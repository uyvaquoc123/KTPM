using StudentApp.Models;
namespace StudentApp.Services
{
    public interface IStudentServices
    {
         List<Student> GetStudents();

         Student? GetStudentById(int studentId);

         Student AddStudent (Student student);

         Student UpdateStudent( Student student);

         bool RemoveStudent (int studentId);
    }
}