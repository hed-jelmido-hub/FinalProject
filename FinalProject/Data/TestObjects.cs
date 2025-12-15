using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class TestObjects
    {
        
    public static List<Student> GetPrePopulatedStudents()
        {
            var students = new List<Student>();

            var student1 = new Student("dan123", "435508240", "Dan Michael", "Francisco", "dfrancisco@example.com", "BSCS - 2");
            student1.SubjectsGrades = new Dictionary<string, double>
        {
            { "Data Structures", 89 },
            { "OOP", 92 },
            { "CFE", 75 },
            { "GSelf", 90 },
            { "GCWorld", 88 },
            { "PEECO", 91 },
            { "Path Fit", 87 },
            { "Calculus", 70 },
            { "COA", 86 }


        };
            student1.SubjectsAbsences = new Dictionary<string, int>
{
                { "Data Structures", 3 },
                { "OOP", 2 },
                 { "CFE", 1 },
                { "GSelf", 0 },
                { "GCWorld", 0 },
                { "PEECO", 7 },
                { "Path Fit", 0 },
                { "Calculus", 2 },
                { "COA", 1 }
};

            

            students.Add(student1);


            var student2 = new Student("velire123", "43533234", "Velire", "Binay-an", "vbinayan@example.com", "BSCS - 2");
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

             
            students.Add(student2);


            var student3 = new Student("jackie123", "49458651", "Jackie", "Elmido", "jelmido@example.com", "BSCS - 2");
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



            students.Add(student3);




            return students;
        }
    }
}

