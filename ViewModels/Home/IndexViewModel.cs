using HCA_Code_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<Class> ClassList { get; set; }
        public List<Teacher> TeacherList { get; set; }
        public List<Student> StudentList { get; set; }
    }
}
