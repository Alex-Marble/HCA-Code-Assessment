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

        #region Student
        public Student GetStudentById(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public List<Student> GetListOfStudents()
        {
            return _context.Students.ToList();
        }

        #endregion

        #region Teacher
        public List<Teacher> GetListOfTeachers()
        {
            return _context.Teachers.ToList();
        }

        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int teacherId)
        {
            var teacher = _context.Teachers.Where(t => t.TeacherId == teacherId).FirstOrDefault();
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }
        #endregion

        #region Class
        public List<Class> GetListOfClasses()
        {
            return _context.Classes.ToList();
        }

        public void AddClass(Class c)
        {
            _context.Classes.Add(c);
            _context.SaveChanges();
        }

        public void DeleteClass(int classId)
        {
            var schoolClass = _context.Classes.Where(c => c.ClassId == classId).FirstOrDefault();
            _context.Classes.Remove(schoolClass);
            _context.SaveChanges();
        }
        #endregion

    }
}
