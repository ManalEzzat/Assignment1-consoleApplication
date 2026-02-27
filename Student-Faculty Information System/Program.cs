using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Mangment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Doctor> doctors = new List<Doctor>();
            List<Course> courses = new List<Course>();

           
            courses.Add(new Course("Software engineer", 3));
            courses.Add(new Course("OOP", 3));
            courses.Add(new Course("Programing 1", 3));
            courses.Add(new Course("Data structuer", 3));
            courses.Add(new Course("Data Base", 3));

            //students.Add(new Student("Amr Tamer", "123", "CS", 0) { Password = "abc" });

            Doctor Doctor1 = new Doctor(courses[0], "Dr.Mohamed","abc");
            Doctor Doctor2 = new Doctor(courses[1], "Dr.Maged", "abc");
            Doctor Doctor3 = new Doctor(courses[2], "Dr.Ahmed", "abc");
            Doctor Doctor4 = new Doctor(courses[3], "Dr.Ehab", "abc");
            Doctor Doctor5 = new Doctor(courses[4], "Dr.Alaa", "abc");

            doctors.Add(Doctor1);
            doctors.Add(Doctor2);
            doctors.Add(Doctor3);
            doctors.Add(Doctor4);
            doctors.Add(Doctor5);

            bool systemRunning = true;

            while (systemRunning)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register (for Student)");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");

                string read = Console.ReadLine();

                if (read == "1") 
                {
                    Console.WriteLine("\nLog in as:");
                    Console.WriteLine("1. Student");
                    Console.WriteLine("2. Doctor");
                    Console.Write("Choice: ");
                    string roleChoice = Console.ReadLine();

                    Console.Write("Enter your ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Enter your Password: ");
                        string password = Console.ReadLine();

                        if (roleChoice == "1")
                        {
                            Student student = students.Find(s => s.UserID == id && s.Password == password);
                            if (student != null)
                            {

                                Student.StudentMenu(student, courses, doctors);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Student ID or Password!");
                            }
                        }
                        else if (roleChoice == "2") 
                        {
                            Doctor doctor = doctors.Find(d => d.UserID == id && d.Password == password);
                            if (doctor != null)
                            {
                                Console.WriteLine($"\nWelcome Doctor! (ID: {doctor.UserID})");
                                Doctor.DoctorMenu(doctor, students);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Doctor ID or Password!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                }
                else if (read == "2")
                {
                    Student.RegisterStudent(students);
  
                }
                else if (read == "3") 
                {
                    systemRunning = false;
                    Console.WriteLine("Exiting System. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Please choose a valid option.");
                }
            }
        }
    
    }
}