using HCA_Code_Assessment.Models;
using HCA_Code_Assessment.Services;
using HCA_Code_Assessment.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Syncfusion.EJ2.Navigations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PersonnelManagementService _personnelService;
        public HomeController(ILogger<HomeController> logger, PersonnelManagementService personnelManagementService)
        {
            _logger = logger;
            _personnelService = personnelManagementService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                StudentList = _personnelService.GetListOfStudents(),
                TeacherList = _personnelService.GetListOfTeachers(),
                ClassList = _personnelService.GetListOfClasses()
            };

            return View(model);
        }

        public IActionResult CreateClass()
        {
            return View();
        }

        public IActionResult EditClass(int classId)
        {
            var classroom = _personnelService.GetClassById(classId);
            return View(classroom);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }
        public IActionResult EditTeacher(int teacherId)
        {
            var teacher = _personnelService.GetTeacherById(teacherId);
            return View(teacher);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        public IActionResult EditStudent(int studentId)
        {
            var student = _personnelService.GetStudentById(studentId);
            return View(student);
        }

        #region Class

        [HttpPost]
        public void AddClass([FromBody] Class c)
        {
            _personnelService.AddClass(c);
        }

        [HttpPut]
        public void UpdateClass([FromBody] Class c)
        {
            _personnelService.UpdateClass(c.ClassId, c.ClassName, c.TeacherId);
        }

        [HttpDelete]
        public void DeleteClass(int classId)
        {
            _personnelService.DeleteClass(classId);
        }

        #endregion

        #region Teacher

        [HttpPost]
        public void AddTeacher([FromBody] Teacher teacher)
        {
            _personnelService.AddTeacher(teacher);
        }

        [HttpPut]
        public void UpdateTeacher([FromBody] Teacher teacher)
        {
            _personnelService.UpdateTeacher(teacher.TeacherId, teacher.FirstName, teacher.LastName);
        }

        [HttpDelete]
        public void DeleteTeacher(int teacherId)
        {
            _personnelService.DeleteTeacher(teacherId);
        }

        #endregion

        #region Student

        [HttpPost]
        public void AddStudent([FromBody] Student student)
        {
            _personnelService.AddStudent(student);
        }

        [HttpPut]
        public void UpdateStudent([FromBody] Student student)
        {
            _personnelService.UpdateStudent(student.StudentId, student.FirstName, student.LastName);
        }

        [HttpDelete]
        public void DeleteStudent(int studentId)
        {
            _personnelService.DeleteStudent(studentId);
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
