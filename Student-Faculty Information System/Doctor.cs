using System;
using System.Collections.Generic;
using System.Text;

namespace Mangment_System
{
    internal class Doctor:User
    {
        public static int count=1;
        public Course Course { get; set; }
        public List<Student> students = new List<Student>();
        public Doctor(Course course , string Name,string password):base(count, password) { 
            
            this.Course = course;
            count++; }

        public bool AddStudent(Student student) {
            if (students.Contains(student)){
                return false;
            }
            students.Add(student);
            return true;
        }
        public Student GetStudent(int id)
        {
            Student student = students.Find(s => s.UserID == id);
            return student;
        }
        public Course GetCourse(Student student)
        {
            Course mycourse = student.courses.Find(c => c.Id == Course.Id);
            return mycourse;
        }
        public void RemoveStudent(int id) {
           Student student = GetStudent(id);
            students.Remove(student);
        }
        public void UpdateStudent(int id,float Score) {
            Student student = GetStudent(id);
            Course course = GetCourse(student);
            course.AddScore(Score);


        }

       public static void DoctorMenu(Doctor doctor, List<Student> allStudents)
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                Console.WriteLine("\n--- DOCTOR MENU ---");
                Console.WriteLine("1. Show My Students");
                Console.WriteLine("2. Add/Update Score for Student");
                Console.WriteLine("3. Add Student to My List");
                Console.WriteLine("4. Log Out");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nYour Students:");
                        if (doctor.students.Count == 0)
                        {
                            Console.WriteLine("No students assigned.");
                        }
                        else
                        {
                            if (doctor.students.Count != 0)
                            {
                                int id = doctor.Course.Id;

                            }
                            foreach (var s in doctor.students)
                            {
                                Console.WriteLine($"ID: {s.UserID} - Name: {s.Name}");
                            }
                        }
                        break;

                    case "2":
                        Console.Write("\nEnter Student ID to grade: ");
                        if (int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            Student studentToGrade = doctor.GetStudent(studentId);

                            if (studentToGrade != null)
                            {
                                Console.Write("Enter Score: ");
                                if (float.TryParse(Console.ReadLine(), out float score))
                                {
                                    try
                                    {
                                        doctor.UpdateStudent(studentId, score);
                                        Console.WriteLine("Score added successfully!");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error: The student must register for your course first before you can grade them.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid score format.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student not found in your list. Please add them first.");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("\nEnter Student ID to add : ");
                        if (int.TryParse(Console.ReadLine(), out int newStudentId))
                        {
                            Student newStudent = allStudents.Find(s => s.UserID == newStudentId);
                            if (newStudent != null)
                            {
                                // Prevent adding the same student
                                if (!doctor.AddStudent(newStudent))
                                {
                                    Console.WriteLine("Student is already in your list.");
                                }
                                else
                                {
                                    doctor.AddStudent(newStudent);
                                    Console.WriteLine($"{newStudent.Name} has been added to your students list!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student not found in the system.");
                            }
                        }
                        break;

                    case "4":
                        loggedIn = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                        break;
                }
            }
        }
        
    }

    
}
