using HCA_Code_Assessment.Models;
using HCA_Code_Assessment.Services;
using HCA_Code_Assessment.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

            var model = new IndexViewModel()
            {
                StudentList = _personnelService.GetListOfStudents(),
                TeacherList = _personnelService.GetListOfTeachers(),
                ClassList = _personnelService.GetListOfClasses()
            };

            return View(model);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public void AddStudent([FromBody]Student student)
        {
            _personnelService.AddStudent(student);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        public void AddTeacher([FromBody]Teacher teacher)
        {
            _personnelService.AddTeacher(teacher);
        }

        public IActionResult CreateClass()
        {
            return View();
        }
        [HttpPost]
        public void AddClass([FromBody]Class c)
        {
            _personnelService.AddClass(c);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
