using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;
namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IRankService _rankService;
        public StudentController(IStudentServices studentService, IDepartmentService departmentService, IRankService rankService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _rankService = rankService;
        }
        public IActionResult Index(string keyword)
        {
            // ViewBag.StudentList = _studentService.GetStudents();
            // ViewData["StudentList"] = _studentService.GetStudents();
            var students = _studentService.GetStudents(keyword);
            return View(students);
        }

        public IActionResult Add()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Departments = _departmentService.GetDepartments();
            mymodel.Ranks = _rankService.GetRanks();
            return View(mymodel);
        }
        public IActionResult Delete(int studentId)
        {
            
            _studentService.RemoveStudent(studentId);
            
            return RedirectToAction("Index");
        }
        public IActionResult Update(int studentId)
        {
            ViewBag.Departments = _departmentService.GetDepartments();
            ViewBag.Ranks = _rankService.GetRanks();

            var student = _studentService.GetStudentById(studentId);
            if (student == null) return RedirectToAction("Add");
            
            return View(student);
        }
        public IActionResult Save(Student student)
        {   
            if (student.Id == 0) _studentService.AddStudent(student);
            else _studentService.UpdateStudent(student);
            
            return RedirectToAction("Index");
        }
    }
}