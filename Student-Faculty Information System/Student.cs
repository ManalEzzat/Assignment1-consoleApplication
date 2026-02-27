using System;
using System.Collections.Generic;
using System.Text;

namespace Mangment_System
{
    internal class Student : User
    {
        public static int count = 1;
        public string Name { get; set; }
        public float GPA { get; set; }
        public string Department { get; set; }
        public int TotalHours { get; set; }
        public List<Course> courses = new List<Course>();
        public Student(string name, string pass, string Department, int hours) : base(count, pass)
        {
            this.Name = name;
            this.Department = Department;
            this.GPA = 0;
            this.TotalHours = 0;
            count++;
        }

        public void addCourse(Course course)
        {
            TotalHours += course.Hour;
            courses.Add(course);
        }

        public void Gpacalc()
        {
            float totalcalc = default;
            if (courses.Count() != 0)
            {
                foreach (Course course in courses)
                {
                    if (course.Score >= 0)
                    {
                        totalcalc += (course.Score) * (course.Hour);
                    }

                }
                GPA = (totalcalc / this.TotalHours);


            }
        }
        public Course FindCourse(int id)
        {
            return courses.Find(c => c.Id == id) ;

        }
        public static void StudentMenu(Student student, List<Course> availableCourses, List<Doctor> doctors)
        {
            student.Gpacalc();
            Console.WriteLine($"\nWelcome {student.Name}! GPA: {student.GPA} ");

            bool loggedIn = true;
            while (loggedIn)
            {
                Console.WriteLine("\n--- STUDENT MENU ---");
                Console.WriteLine("1. Show Registered Courses");
                Console.WriteLine("2. Register for a New Course");
                Console.WriteLine("3. Log Out");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nYour Registered Courses:");
                        if (student.courses.Count == 0)
                        {
                            Console.WriteLine("You have no courses registered yet.");
                        }
                        else
                        {
                            foreach (var c in student.courses)
                            {
                                Console.WriteLine($"- {c.Name} (Hours: {c.Hour}, Score: {c.Score})");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("\nAvailable Courses:");
                        foreach (var c in availableCourses)
                        {
                            Console.WriteLine($"ID: {c.Id} - {c.Name}");
                        }
                        Console.Write("Enter the ID of the course to register: ");
                        if (int.TryParse(Console.ReadLine(), out int courseId))
                        {
                            Course selectedCourse = availableCourses.Find(c => c.Id == courseId);
                            if (selectedCourse != null)
                            {
                                if (student.courses.Exists(c => c.Id == selectedCourse.Id))
                                {
                                    Console.WriteLine("You are already registered for this course.");
                                }
                                else
                                {

                                    student.addCourse(selectedCourse);



                                    foreach (Doctor doc in doctors)
                                    {
                                        if (doc.Course.Id == selectedCourse.Id)
                                        {
                                            // Prevent adding the same student
                                            if (!doc.AddStudent(student))
                                            {
                                                doc.AddStudent(student);
                                            }
                                        }
                                    }

                                    Console.WriteLine($"Successfully registered for {selectedCourse.Name}!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        break;
                    case "3":
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public static void RegisterStudent(List<Student> students)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            while (name == "")
            {
                Console.Write("Please Enter Name: ");
                name = Console.ReadLine();

            }
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            while (pass == "")
            {
                Console.Write("Please Enter Password: ");
                pass = Console.ReadLine();

            }
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();
            while (dept == "")
            {
                Console.Write("Please Enter Department Name: ");
                dept = Console.ReadLine();

            }


            Student newStudent = new Student(name, pass, dept, 0);
            students.Add(newStudent);
            Console.WriteLine($"Student registered successfully! Your ID is: {newStudent.UserID}");
        }

    }
}
