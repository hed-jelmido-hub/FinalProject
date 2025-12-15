using FinalProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudentByEmailAndPassword(string email, string password);
        bool EmailExists(string email);
        bool StudentIDExists(string studentId);
        public List<Student> GetAllStudents();
        public void UpdateStudent(Student student);
        public Student GetStudentByEmail(string email);
    }
}