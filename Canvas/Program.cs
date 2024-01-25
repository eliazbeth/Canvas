﻿using System;
using System.Runtime.CompilerServices;
using Canvas.Models;

namespace Canvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            List<Person> students = new List<Person>();
            PrintMenu();
            Console.WriteLine("Choose an option:");
            var choice = Console.ReadLine();
            while(choice != "0")
            {   
                switch(choice)
                {
                    case "1":   AddCourse(courses);
                        break;
                    case "2":   ListCourses(courses);
                        break;
                    case "3":   AddStudentToCourse(students, courses);
                        break;
                    case "4":   RemoveStudentFromCourse(students, courses);
                        break;
                    case "5":   SearchCourse(courses);
                        break;
                    case "6":   AddAssignment(courses);
                        break;
                    case "7":
                        break;
                    case "8":   AddStudent(students);
                        break;
                    case "9":   ListStudents(students);
                        break;
                    case "10":  SearchStudentByName(students);
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "0":
                        break;
                }
                PrintMenu();
                Console.WriteLine("Choose an option:");
                choice = Console.ReadLine();
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add a course");
            Console.WriteLine("2. List courses");
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. Search for a course");
            Console.WriteLine("6. Add an assignment to a course");
            Console.WriteLine("7. Update course information");
            Console.WriteLine();
            Console.WriteLine("8. Add a student");
            Console.WriteLine("9. List students");
            Console.WriteLine("10. Search for a student");
            Console.WriteLine("11. List courses taken by a student");
            Console.WriteLine("12. Update student information");
            Console.WriteLine();
            Console.WriteLine("0. Exit menu");
        }
        public static void AddCourse(List<Course> courses)
        {
                Console.WriteLine("Course Code:");
                var code = Console.ReadLine();

                Console.WriteLine("Course Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Course Description:");
                var description = Console.ReadLine();

                Course myCourse = new Course{Code = code, Name = name, Description = description};
                courses.Add(myCourse);
        }
        public static void AddStudent(List<Person> students)
        {
                Console.WriteLine("Student Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Student Classification:");
                var classification = Console.ReadLine();

                Person myStudent = new Person{Name = name, Classification = classification};
                students.Add(myStudent);
        }
        public static void AddStudentToCourse(List<Person> students, List<Course> courses)
        {
            ListCourses(courses);
            Console.WriteLine("Choose a course: ");
            var course = Console.ReadLine();
            var courseInt = int.Parse(course ?? "0");
            courseInt--;
            
            ListStudents(students);
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "0");
            studentInt--;

            courses[courseInt].Roster?.Add(students[studentInt]);
            Console.WriteLine($"Roster for {courses[courseInt].Name}:");
            foreach(Person s in courses[courseInt].Roster)
            {
                Console.WriteLine(s);
            }
        }
        public static void RemoveStudentFromCourse(List<Person> students, List<Course> courses)
        {
            ListCourses(courses);
            Console.WriteLine("Choose a course: ");
            var course = Console.ReadLine();
            var courseInt = int.Parse(course ?? "0");
            courseInt--;

            ListStudents(courses[courseInt].Roster);
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "0");
            studentInt--;
            Person theStudent = courses[courseInt].Roster[studentInt];

            courses[courseInt].Roster?.Remove(theStudent);
            Console.WriteLine($"Roster for {courses[courseInt].Name}:");
            foreach(Person s in courses[courseInt].Roster)
            {
                Console.WriteLine(s);
            }
        }

        public static void ListCourses(List<Course> courses)
        {
            int count = 1;
            Console.WriteLine("Courses:");
            foreach(Course c in courses)
            {
                Console.WriteLine($"{count++}. {c}");
            }
            Console.WriteLine();
        }

        public static void ListStudents(List<Person> students)
        {
            int count = 1;
            Console.WriteLine("Students:");
            foreach(Person s in students)
            {
                Console.WriteLine($"{count++}. {s}");
            }
            Console.WriteLine();
        }

        public static void SearchCourse(List<Course> courses)
        {
            Console.WriteLine($"Enter 's' to search by name or 'd' to search by description: ");
            var choice = Console.ReadLine();
          
            if(choice == "s")
            {
                Console.WriteLine("Enter the name to search for:");
                var name = Console.ReadLine();
                if(SearchCourseByName(name ?? " ", courses))
                {
                    Console.WriteLine("Course was found.");
                }
                else 
                    Console.WriteLine("Course was not found.");
            }   
            if(choice == "d")
            {
                Console.WriteLine("Enter the description to search for:");
                var description = Console.ReadLine();
                if(SearchCourseByDescription(description ?? " ", courses))
                {
                    Console.WriteLine("Course was found.");
                }
                else 
                    Console.WriteLine("Course was not found.");
            }  
        }
        public static bool SearchCourseByName(string name, List<Course> courses)
        {
            if(courses.Find(c => c.Name == name) != null)
                return true;
            return false;
        }
        public static bool SearchCourseByDescription(string description, List<Course> courses)
        {
            if(courses.Find(c => c.Description == description) != null)
                return true;
            return false;
        }

        public static void SearchStudentByName(List<Person> students)
        {
            Console.WriteLine($"Enter student name to search: ");
            var name = Console.ReadLine();
            if(students.Find(s => s.Name == name) != null)
                Console.WriteLine("Student was found.");
            else
                Console.WriteLine("Student was not found.");
        }

        public static void AddAssignment(List<Course> courses)
        {
            ListCourses(courses);
            Console.WriteLine("Choose a course: ");
            var course = Console.ReadLine();
            var courseInt = int.Parse(course ?? "0");
            courseInt--;

            Console.WriteLine("Enter name for assignment ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter description: ");
            var description = Console.ReadLine();
            Console.WriteLine("Enter available points: ");
            var points = Console.ReadLine();   
            double pointsDbl = double.Parse(points ?? "100"); 
            Console.WriteLine("Enter the due date and time in the form 'dd/mm/yy hh:mm:ss'");
            var datetimeStr = Console.ReadLine();
            DateTime datetime = DateTime.Parse(datetimeStr ?? "0");

            Assignment assignment = new Assignment{Name = name, Description = description, TotalAvailablePoints = pointsDbl, DueDate = datetime};
            courses[courseInt].Assignments.Add(assignment);
            Console.WriteLine($"Assignments for {courses[courseInt].Name}:");
            foreach(Assignment a in courses[courseInt].Assignments)
            {
                Console.WriteLine($"{a.Name} Due {a.DueDate}");
            }
        }
    }
}