using FinalProject.Data;
using FinalProject.Databasecontext;
using FinalProject.Models;
using FinalProject.Repositories;
using static FinalProject.Models.Student;

namespace FinalProject
{
    internal static class Program
    {
        public static DatabaseContext DbContext;
        public static IStudentRepository studRepo;

        [STAThread]
        static void Main()
        {
            string dbPath = Path.Combine(Application.StartupPath, "app.db");

            DbContext = new DatabaseContext(dbPath);
            studRepo = new StudentRepository(DbContext);

            ApplicationConfiguration.Initialize();
            TestAcc();
            Application.Run(new Entrance());
        }
        

        private static void TestAcc()
        {
            string email = "dfrancisco@example.com";
            Student student1;

            if (studRepo.EmailExists(email))
            {
                student1 = studRepo.GetStudentByEmail(email);

            }
            else
                
            {
               
                student1 = new Student(
                    "dan123",
                    "435508240",
                    "Dan Michael",
                    "Francisco",
                    email,
                    "BSCS - 2"
                );
                student1.SubjectsGrades = new Dictionary<string, double>
            {
                { "Data Structures", 75 },
                { "OOP", 75 },
                { "CFE", 74 },
                { "GSelf", 90 },
                { "GCWorld", 70 },
                { "PEECO", 75 },
                { "Path Fit", 75 },
                { "Calculus", 70 },
                { "COA", 86 }
            };
                student1.SubjectsAbsences = new Dictionary<string, int>

    {
                    { "Data Structures", 4 },
                    { "OOP", 2 },
                    { "CFE", 1 },
                    { "GSelf", 9 },
                    { "GCWorld", 10 },
                    { "PEECO", 7 },
                    { "Path Fit", 7 },
                    { "Calculus", 2 },
                    { "COA", 8 }
    };
                student1.AcademicSubjects = new List<AcademicSubject>
{
    // FIRST YEAR
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Programming 1", Units = 3, Grade = 85 },
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Math 1", Units = 3, Grade = 80 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Programming 2", Units = 3, Grade = 82 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Math 2", Units = 3, Grade = 78 },
    new AcademicSubject { YearLevel = 1, Semester = "Midyear", SubjectName = "NSTP", Units = 3, Grade = 90 },

    //  SECOND YEAR 
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Data Structures", Units = 3, Grade = 75 },
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Calculus 3", Units = 3, Grade = 80 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "OOP", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "Discrete Math", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 2, Semester = "Midyear", SubjectName = "PE", Units = 2, Grade = 0 },

    //  THIRD YEAR
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Database Systems", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Computer Networks", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "AI Fundamentals", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "Software Engineering", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "Midyear", SubjectName = "Elective 1", Units = 3, Grade = 0 },

    // FOURTH YEAR 
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Machine Learning", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Web Development", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Capstone Project", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Elective 2", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "Midyear", SubjectName = "Internship", Units = 3, Grade = 0 }
};

                student1.AcademicRecord = new Dictionary<string, Dictionary<string, (int Units, double? Grade)>>
{
    // FIRST YEAR
    { "1st Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 1", (3, 85) },
            { "Math 1", (3, 80) }
        }
    },
    { "1st Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 2", (3, 82) },
            { "Math 2", (3, 78) }
        }
    },
    { "1st Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "NSTP", (3, 90) }
        }
    },

    //  SECOND YEAR
    { "2nd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Data Structures", (3, 75) },
            { "Calculus 3", (3, 80) }
        }
    },
    { "2nd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "OOP", (3, null) },
            { "Discrete Math", (3, null) }
        }
    },
    { "2nd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "PE", (2, null) }
        }
    },

    // THIRD YEAR 
    { "3rd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Database Systems", (3, null) },
            { "Computer Networks", (3, null) }
        }
    },
    { "3rd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "AI Fundamentals", (3, null) },
            { "Software Engineering", (3, null) }
        }
    },
    { "3rd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Elective 1", (3, null) }
        }
    },

    // ===== FOURTH YEAR =====
    { "4th Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Machine Learning", (3, null) },
            { "Web Development", (3, null) }
        }
    },
    { "4th Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Capstone Project", (3, null) },
            { "Elective 2", (3, null) }
        }
    },
    { "4th Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Internship", (3, null) }
        }
    }
};

                student1.FirstTermBalance = 10500;   
                student1.MidTermBalance = 12000;    
                student1.MidYearBalance = 8500;     
                student1.FinalTermBalance = 10800;

                student1.TotalAbsences = student1.SubjectsAbsences.Values.Sum();

                if (studRepo.EmailExists(email))
                    studRepo.UpdateStudent(student1);
                else
                    studRepo.AddStudent(student1);
                student1.Schedule = new Dictionary<string, List<ScheduleEntry>>
{
                {  "MTh", new List<ScheduleEntry>
        {
                 new ScheduleEntry { Subject = "Data Structures", Time = "7:30 AM - 10:00 AM" },
                 new ScheduleEntry { Subject = "GSelf", Time = "10:30 AM - 12:00 PM" },
                 new ScheduleEntry { Subject = "PEECO", Time = "1:30 PM - 3:00 PM" },
                 new ScheduleEntry { Subject = "CSMath", Time = "4:30 PM - 6:30 PM" }
        }
               },
                 { "TF", new List<ScheduleEntry>
        {
                  new ScheduleEntry { Subject = "CFE", Time = "7:30 AM - 9:00 AM" },
                  new ScheduleEntry { Subject = "PATHFIT", Time = "9:00 AM - 10:00 AM" },
                  new ScheduleEntry { Subject = "OOP", Time = "10:30 AM - 1:00 PM" },
                  new ScheduleEntry { Subject = "COA", Time = "1:30 PM - 4:30 PM" },
                  new ScheduleEntry { Subject = "GCWorld", Time = "4:30 PM - 6:00 PM" }
        }
    }
};

                studRepo.UpdateStudent(student1);
            }



             email = "vbinayan@example.com";
            Student student2;
            if (studRepo.EmailExists(email))
            {
                student1 = studRepo.GetStudentByEmail(email);

            }
            else

            {

                student2 = new Student(
                    "velire123",
                    "43533234",
                    "Velire",
                    "Binay-An",
                    email,
                    "BSCS - 2"
                );

                student2.SubjectsGrades = new Dictionary<string, double>
            {
                { "Data Structures", 90 },
                { "OOP", 80 },
                { "CFE", 74 },
                { "GSelf", 82 },
                { "GCWorld", 77 },
                { "PEECO", 85 },
                { "Path Fit", 79 },
                { "Calculus", 88 },
                { "COA", 75 }
            };
                student2.SubjectsAbsences = new Dictionary<string, int>
                    {
                { "Data Structures", 4 },
                { "OOP", 0},
                { "CFE", 2 },
                { "GSelf", 0 },
                { "GCWorld", 0 },
                { "PEECO", 3 },
                { "Path Fit", 0 },
                { "Calculus", 2 },
                { "COA", 1 }
    };
                student2.AcademicSubjects = new List<AcademicSubject>
{
    // FIRST YEAR
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Programming 1", Units = 3, Grade = 95 },
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Math 1", Units = 3, Grade = 88 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Programming 2", Units = 3, Grade = 90 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Math 2", Units = 3, Grade = 88 },
    new AcademicSubject { YearLevel = 1, Semester = "Midyear", SubjectName = "NSTP", Units = 3, Grade = 90 },

    //  SECOND YEAR 
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Data Structures", Units = 3, Grade = 90 },
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Calculus 3", Units = 3, Grade = 88 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "OOP", Units = 3, Grade = 80 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "Discrete Math", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 2, Semester = "Midyear", SubjectName = "PE", Units = 2, Grade = 0 },

    //  THIRD YEAR
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Database Systems", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Computer Networks", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "AI Fundamentals", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "Software Engineering", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "Midyear", SubjectName = "Elective 1", Units = 3, Grade = 0 },

    // FOURTH YEAR 
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Machine Learning", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Web Development", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Capstone Project", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Elective 2", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "Midyear", SubjectName = "Internship", Units = 3, Grade = 0 }
};

                student2.AcademicRecord = new Dictionary<string, Dictionary<string, (int Units, double? Grade)>>
{
    // FIRST YEAR
    { "1st Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 1", (3, 85) },
            { "Math 1", (3, 80) }
        }
    },
    { "1st Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 2", (3, 82) },
            { "Math 2", (3, 78) }
        }
    },
    { "1st Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "NSTP", (3, 90) }
        }
    },

    //  SECOND YEAR
    { "2nd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Data Structures", (3, 75) },
            { "Calculus 3", (3, 80) }
        }
    },
    { "2nd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "OOP", (3, null) },
            { "Discrete Math", (3, null) }
        }
    },
    { "2nd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "PE", (2, null) }
        }
    },

    // THIRD YEAR 
    { "3rd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Database Systems", (3, null) },
            { "Computer Networks", (3, null) }
        }
    },
    { "3rd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "AI Fundamentals", (3, null) },
            { "Software Engineering", (3, null) }
        }
    },
    { "3rd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Elective 1", (3, null) }
        }
    },

    // ===== FOURTH YEAR =====
    { "4th Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Machine Learning", (3, null) },
            { "Web Development", (3, null) }
        }
    },
    { "4th Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Capstone Project", (3, null) },
            { "Elective 2", (3, null) }
        }
    },
    { "4th Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Internship", (3, null) }
        }
    }
};

                student2.FirstTermBalance = 9700;
                student2.MidTermBalance = 11000;
                student2.MidYearBalance = 8100;
                student2.FinalTermBalance = 7800;

                student2.TotalAbsences = student1.SubjectsAbsences.Values.Sum();

                if (studRepo.EmailExists(email))
                    studRepo.UpdateStudent(student2);
                else
                    studRepo.AddStudent(student2);
                student2.Schedule = new Dictionary<string, List<ScheduleEntry>>
{
                {  "MTh", new List<ScheduleEntry>
        {
                 new ScheduleEntry { Subject = "Data Structures", Time = "7:30 AM - 10:00 AM" },
                 new ScheduleEntry { Subject = "GSelf", Time = "10:30 AM - 12:00 PM" },
                 new ScheduleEntry { Subject = "PEECO", Time = "1:30 PM - 3:00 PM" },
                 new ScheduleEntry { Subject = "CSMath", Time = "4:30 PM - 6:30 PM" }
        }
               },
                 { "TF", new List<ScheduleEntry>
        {
                  new ScheduleEntry { Subject = "GCWorld", Time = "7:30 AM - 9:00 AM" },
                  new ScheduleEntry { Subject = "PATHFIT", Time = "9:00 AM - 10:00 AM" },
                  new ScheduleEntry { Subject = "OOP", Time = "10:30 AM - 1:00 PM" },
                  new ScheduleEntry { Subject = "COA", Time = "1:30 PM - 4:30 PM" },
                  new ScheduleEntry { Subject = "CFE", Time = "4:30 PM - 6:00 PM" }
        }
    }
};

                studRepo.UpdateStudent(student2);
            }



            email = "jelmido@example.com";
            Student student3;
            if (studRepo.EmailExists(email))
            {
                student3 = studRepo.GetStudentByEmail(email);

            }
            else

            {

                student3 = new Student(
                    "jackie123",
                    "49458651",
                    "Jackie",
                    "Elmido",
                    email,
                    "BSCS - 2"
                );

                student3.SubjectsGrades = new Dictionary<string, double>
            {
                { "Data Structures", 75 },
                { "OOP", 70 },
                { "CFE", 75 },
                { "GSelf", 74 },
                { "GCWorld", 88 },
                { "PEECO", 71 },
                { "Path Fit", 75 },
                { "Calculus", 79 },
                { "COA", 86 }
            };
                student3.SubjectsAbsences = new Dictionary<string, int>
                    {
                { "Data Structures", 5 },
                { "OOP", 3 },
                { "CFE", 7 },
                { "GSelf", 8 },
                { "GCWorld", 7 },
                { "PEECO", 7 },
                { "Path Fit", 0 },
                { "Calculus", 2 },
                { "COA", 6 }
    };
                student3.AcademicSubjects = new List<AcademicSubject>
{
    // FIRST YEAR
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Programming 1", Units = 3, Grade = 75 },
    new AcademicSubject { YearLevel = 1, Semester = "1st", SubjectName = "Math 1", Units = 3, Grade = 80 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Programming 2", Units = 3, Grade = 74 },
    new AcademicSubject { YearLevel = 1, Semester = "2nd", SubjectName = "Math 2", Units = 3, Grade = 78 },
    new AcademicSubject { YearLevel = 1, Semester = "Midyear", SubjectName = "NSTP", Units = 3, Grade = 90 },

    //  SECOND YEAR 
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Data Structures", Units = 3, Grade = 75 },
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "Calculus 3", Units = 3, Grade = 79 },
    new AcademicSubject { YearLevel = 2, Semester = "1st", SubjectName = "GSelf", Units = 3, Grade = 74 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "OOP", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 2, Semester = "2nd", SubjectName = "Discrete Math", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 2, Semester = "Midyear", SubjectName = "PE", Units = 2, Grade = 0 },

    //  THIRD YEAR
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Database Systems", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "1st", SubjectName = "Computer Networks", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "AI Fundamentals", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "2nd", SubjectName = "Software Engineering", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 3, Semester = "Midyear", SubjectName = "Elective 1", Units = 3, Grade = 0 },

    // FOURTH YEAR 
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Machine Learning", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "1st", SubjectName = "Web Development", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Capstone Project", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "2nd", SubjectName = "Elective 2", Units = 3, Grade = 0 },
    new AcademicSubject { YearLevel = 4, Semester = "Midyear", SubjectName = "Internship", Units = 3, Grade = 0 }
};

                student3.AcademicRecord = new Dictionary<string, Dictionary<string, (int Units, double? Grade)>>
{
    // FIRST YEAR
    { "1st Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 1", (3, 85) },
            { "Math 1", (3, 80) }
        }
    },
    { "1st Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Programming 2", (3, 82) },
            { "Math 2", (3, 78) }
        }
    },
    { "1st Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "NSTP", (3, 90) }
        }
    },

    //  SECOND YEAR
    { "2nd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Data Structures", (3, 75) },
            { "Calculus 3", (3, 80) }
        }
    },
    { "2nd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "OOP", (3, null) },
            { "Discrete Math", (3, null) }
        }
    },
    { "2nd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "PE", (2, null) }
        }
    },

    // THIRD YEAR 
    { "3rd Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Database Systems", (3, null) },
            { "Computer Networks", (3, null) }
        }
    },
    { "3rd Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "AI Fundamentals", (3, null) },
            { "Software Engineering", (3, null) }
        }
    },
    { "3rd Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Elective 1", (3, null) }
        }
    },

    // ===== FOURTH YEAR =====
    { "4th Year - 1st Semester", new Dictionary<string, (int, double?)>
        {
            { "Machine Learning", (3, null) },
            { "Web Development", (3, null) }
        }
    },
    { "4th Year - 2nd Semester", new Dictionary<string, (int, double?)>
        {
            { "Capstone Project", (3, null) },
            { "Elective 2", (3, null) }
        }
    },
    { "4th Year - Midyear", new Dictionary<string, (int, double?)>
        {
            { "Internship", (3, null) }
        }
    }
};

                student3.FirstTermBalance = 11700;
                student3.MidTermBalance = 15950;
                student3.MidYearBalance = 1610;
                student3.FinalTermBalance = 3400;

                student3.TotalAbsences = student1.SubjectsAbsences.Values.Sum();

                if (studRepo.EmailExists(email))
                    studRepo.UpdateStudent(student3);
                else
                    studRepo.AddStudent(student3);
                student3.Schedule = new Dictionary<string, List<ScheduleEntry>>
{
                {  "MTh", new List<ScheduleEntry>
        {
                 new ScheduleEntry { Subject = "Data Structures", Time = "7:30 AM - 10:00 AM" },
                 new ScheduleEntry { Subject = "GSelf", Time = "10:30 AM - 12:00 PM" },
                 new ScheduleEntry { Subject = "PEECO", Time = "1:30 PM - 3:00 PM" },
                 new ScheduleEntry { Subject = "CSMath", Time = "4:30 PM - 6:30 PM" }
        }
               },
                 { "TF", new List<ScheduleEntry>
        {
                  new ScheduleEntry { Subject = "GCWorld", Time = "7:30 AM - 9:00 AM" },
                  new ScheduleEntry { Subject = "PATHFIT", Time = "9:00 AM - 10:00 AM" },
                  new ScheduleEntry { Subject = "OOP", Time = "10:30 AM - 1:00 PM" },
                  new ScheduleEntry { Subject = "COA", Time = "1:30 PM - 4:30 PM" },
                  new ScheduleEntry { Subject = "CFE", Time = "4:30 PM - 6:00 PM" }
        }
    }
};

                studRepo.UpdateStudent(student3);
            }
           
            }
        }
    }
