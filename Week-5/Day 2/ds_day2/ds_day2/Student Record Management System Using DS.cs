using System;
using System.Collections.Generic;

namespace ds_day2
{
    public record Student(int RollNo, string Name, string Course, int Marks);

    internal class Student_Record_Management_System_Using_DS
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            Console.Write("Enter number of students: ");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Invalid number of students.");
                return;
            }

           
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for student {i + 1}");

                int rollNo;
                do
                {
                    Console.Write("Enter Roll Number: ");
                } while (!int.TryParse(Console.ReadLine(), out rollNo) || rollNo <= 0);

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                do
                {
                    Console.Write("Enter Marks (0–100): ");
                } while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100);

                students.Add(new Student(rollNo, name, course, marks));
            }

            int choice;
            do
            {
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search Student by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        DisplayStudents(students);
                        break;

                    case 2:
                        Console.Write("Enter Roll Number to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchRoll))
                            SearchStudent(students, searchRoll);
                        else
                            Console.WriteLine("Invalid Roll Number.");
                        break;

                    case 3:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 3);
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        static void SearchStudent(List<Student> students, int rollNo)
        {
            var student = students.Find(s => s.RollNo == rollNo);

            Console.WriteLine("\nSearch Result:");
            if (student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine($"Roll No: {student.RollNo} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
