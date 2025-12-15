using FinalProject.Databasecontext;
using FinalProject.Models;
using Newtonsoft.Json;
using SQLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject.Models.Student;


namespace FinalProject.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _dbContext;

        public StudentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        
       public void AddStudent(Student student)
        {
            if (student.SubjectsGrades != null && student.SubjectsGrades.Count > 0)
            
                student.GradesJson = JsonConvert.SerializeObject(student.SubjectsGrades);
            

            if (student.SubjectsAbsences != null && student.SubjectsAbsences.Count > 0)
            
                student.AbsencesJson = JsonConvert.SerializeObject(student.SubjectsAbsences);

            if (student.Schedule != null && student.Schedule.Count > 0)

                student.ScheduleJson = JsonConvert.SerializeObject(student.Schedule);


            _dbContext.Connection.Insert(student);


        }
        

        public bool EmailExists(string email)
        {
            return _dbContext.Connection.Table<Student>()
                      .Any(s => s.Email == email);
        }

        public bool StudentIDExists(string studentId)
        {
            return _dbContext.Connection.Table<Student>()
                      .Any(s => s.StudentID == studentId);
        }

        public Student GetStudentByEmailAndPassword(string email, string password)
        {
            var student = _dbContext.Connection.Table<Student>()
                     .FirstOrDefault(s => s.Email == email && s.Password == password);

            if (student != null)
            {
                if (!string.IsNullOrEmpty(student.GradesJson))
                {

                    student.SubjectsGrades =
                        JsonConvert.DeserializeObject<Dictionary<string, double>>(student.GradesJson);
                }

                else
                {
                    student.SubjectsGrades = new Dictionary<string, double>();
                }
                if (!string.IsNullOrEmpty(student.AbsencesJson))
                {
                    student.SubjectsAbsences =
                        JsonConvert.DeserializeObject<Dictionary<string, int>>(student.AbsencesJson);
                }
                else
                {
                    student.SubjectsAbsences = new Dictionary<string, int>();
                }
                if (!string.IsNullOrEmpty(student.ScheduleJson))
                {
                    student.Schedule =
                        JsonConvert.DeserializeObject<Dictionary<string, List<ScheduleEntry>>>(student.ScheduleJson);
                }
                else
                {
                    student.Schedule = new Dictionary<string, List<ScheduleEntry>>();
                }

            }
            return student;
        }
        public List<Student> GetAllStudents()
        {
            var students = _dbContext.Connection.Table<Student>().ToList();

            foreach (var student in students)
            {
                if (!string.IsNullOrEmpty(student.GradesJson))
                {
                    student.SubjectsGrades =
                        JsonConvert.DeserializeObject<Dictionary<string, double>>(student.GradesJson);
                }
                else
                {
                    student.SubjectsGrades = new Dictionary<string, double>();
                }
            }

            return students;
        }
        public void UpdateStudent(Student student)
        {
            if (student.SubjectsGrades != null && student.SubjectsGrades.Count > 0)
            
                student.GradesJson = JsonConvert.SerializeObject(student.SubjectsGrades);
            

            if (student.SubjectsAbsences != null && student.SubjectsAbsences.Count > 0)
            
                student.AbsencesJson = JsonConvert.SerializeObject(student.SubjectsAbsences);
            
            else
                student.AbsencesJson = null;

            if (student.Schedule != null && student.Schedule.Count > 0)
                student.ScheduleJson = JsonConvert.SerializeObject(student.Schedule);

            _dbContext.Connection.Update(student);
        }
        public Student GetStudentByEmail(string email)
        {
            var student = _dbContext.Connection.Table<Student>()
                         .FirstOrDefault(s => s.Email == email);

            if (student != null)
            {
                if (!string.IsNullOrEmpty(student.GradesJson))
                    student.SubjectsGrades =
                        JsonConvert.DeserializeObject<Dictionary<string, double>>(student.GradesJson);
                else
                    student.SubjectsGrades = new Dictionary<string, double>();

                if (!string.IsNullOrEmpty(student.AbsencesJson))
                    student.SubjectsAbsences =
                        JsonConvert.DeserializeObject<Dictionary<string, int>>(student.AbsencesJson);
                else
                    student.SubjectsAbsences = new Dictionary<string, int>();
            }

            return student;
        }

    }
}
