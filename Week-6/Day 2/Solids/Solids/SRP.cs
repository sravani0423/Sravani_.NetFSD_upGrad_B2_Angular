using System;
using System.Collections.Generic;

namespace Solids
{
    // Renamed Entity (to avoid conflict)
    public class StudentSRP
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public double Marks { get; set; }
    }

    // Renamed Repository
    public class StudentRepositorySRP
    {
        private List<StudentSRP> students = new List<StudentSRP>();

        public void AddStudent(StudentSRP student)
        {
            students.Add(student);
        }

        public List<StudentSRP> GetAllStudents()
        {
            return students;
        }
    }

    // Report Generator (Single Responsibility)
    public class ReportGeneratorSRP
    {
        public void GenerateReport(List<StudentSRP> students)
        {
            Console.WriteLine("----- Student Report -----");

            foreach (var student in students)
            {
                string result = student.Marks >= 40 ? "Pass" : "Fail";

                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Result: {result}");
                Console.WriteLine("------");
            }
        }
    }

    // Main Program
    internal class SRPProgram
    {
        public static void Main(string[] args)
        {
            StudentRepositorySRP repo = new StudentRepositorySRP();

            repo.AddStudent(new StudentSRP { StudentId = 1, StudentName = "Vaani", Marks = 90 });
            repo.AddStudent(new StudentSRP { StudentId = 2, StudentName = "Sonu", Marks = 63 });
            repo.AddStudent(new StudentSRP { StudentId = 3, StudentName = "Seno", Marks = 75 });
            repo.AddStudent(new StudentSRP { StudentId = 4, StudentName = "Mohit", Marks = 32 });

            ReportGeneratorSRP report = new ReportGeneratorSRP();
            report.GenerateReport(repo.GetAllStudents());

            Console.ReadLine();
        }
    }
}
