using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Text.Json;
using Newtonsoft.Json;
namespace FinalProject.Models
{
   
     public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int TotalAbsences { get; set; } = 0;
        public double CurrentBalance { get; set; } = 0.0;
        public string CourseAndYear { get; set; }

        public string GradesJson { get; set; }
        public string AbsencesJson { get; set; }
        public double FirstTermBalance { get; set; }
        public double MidTermBalance { get; set; }
        public double MidYearBalance { get; set; }
        public double FinalTermBalance { get; set; }
        public string ScheduleJson { get; set; }
        public string AcademicRecordJson { get; set; }
        [Ignore]
        public Dictionary<string, Dictionary<string, (int Units, double? Grade)>> AcademicRecord
        { get; set; } = new();
        [Ignore]
        public List<AcademicSubject> AcademicSubjects { get; set; } = new();
        [Ignore]
        public Dictionary<string, List<ScheduleEntry>> Schedule { get; set; } = new Dictionary<string, List<ScheduleEntry>>();
        [Ignore]
        public Dictionary<string, int> SubjectsAbsences { get; set; }
            = new Dictionary<string, int>();

        [Ignore]
        public Dictionary<string, double> SubjectsGrades { get; set; } 
            = new Dictionary<string, double>();
        public class AcademicSubject
        {
            public int YearLevel { get; set; }   
            public string Semester { get; set; } 
            public string SubjectName { get; set; }
            public int Units { get; set; }
            public double Grade { get; set; }
            
        }

        public Student(string password,string studentId, string first,
        string last , string email, string courseAndYear,

          Dictionary<string, double>? grades = null,
        Dictionary<string, int>? absences = null)

        {
            Password = password;
            StudentID = studentId;
            FirstName = first;
            LastName = last;
            Email = email;
            CourseAndYear = courseAndYear;

            TotalAbsences = 0;
            CurrentBalance = 0.0;

            if (grades != null)
                SubjectsGrades = grades;

            if (absences != null)
                SubjectsAbsences = absences;
        }
        public class ScheduleEntry
        {
            public string Subject { get; set; }
            public string Time { get; set; }

            [JsonIgnore]
            public DateTime StartTime => DateTime.Parse(Time.Split(" - ")[0]);
            [JsonIgnore]
            public DateTime EndTime => DateTime.Parse(Time.Split(" - ")[1]);
        }





        public Student() { }
    }
}

