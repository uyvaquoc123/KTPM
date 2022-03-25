using Microsoft.AspNetCore.Mvc;
using StudentApp.Services;
namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentService;
        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            // ViewBag.StudentList = _studentService.GetStudents();
            // ViewData["StudentList"] = _studentService.GetStudents();
            var students = _studentService.GetStudents();
            return View(students);
        }
    }
}