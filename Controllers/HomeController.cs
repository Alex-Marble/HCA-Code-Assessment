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
            ViewBag.Student = _personnelService.GetStudentById(1);

            ViewBag.headerText0 = new TabHeader { Text = "Classes" };
            ViewBag.headerText1 = new TabHeader { Text = "Teahcers" };
            ViewBag.headerText2 = new TabHeader { Text = "Students" };

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

        public IActionResult CreateTeacher()
        {
            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        #region Class

        [HttpPost]
        public void AddClass([FromBody] Class c)
        {
            _personnelService.AddClass(c);
        }

        [HttpPut]
        public void UpdateClass(int classId, string className, int teacherId)
        {
            _personnelService.UpdateClass(classId, className, teacherId);
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
        public void UpdateTeacher(int teacherId, string firstName, string lastName)
        {
            _personnelService.UpdateTeacher(teacherId, firstName, lastName);
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
        public void UpdateStudent(int studentId, string firstName, string lastName)
        {
            _personnelService.UpdateStudent(studentId, firstName, lastName);
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
