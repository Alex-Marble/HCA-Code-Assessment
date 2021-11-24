using HCA_Code_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Services
{
    public class PersonnelManagementService
    {
        private AppDbContext _context;

        public PersonnelManagementService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public List<Student> GetListOfStudents()
        {
            return _context.Students.ToList();
        }

        public List<Teacher> GetListOfTeachers()
        {
            return _context.Teachers.ToList();
        }

        public List<Class> GetListOfClasses()
        {
            return _context.Classes.ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
        public void AddClass(Class c)
        {
            _context.Classes.Add(c);
            _context.SaveChanges();
        }
    }
}
