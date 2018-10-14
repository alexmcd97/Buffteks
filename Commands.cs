using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Buffteks
{
    class  Commands
    {

        public static void DisplayAllStudent()
        {
            using(var db = new AppDbContext())
            {
                foreach (var Student in db.Students)
                {
                    Console.WriteLine($"Student {Student.StudentID}");
                    Console.WriteLine($"First Name: {Student.FirstName}");
                    Console.WriteLine($"Last Name: {Student.LastName}");
                    Console.WriteLine($"Phone Number: {Student.Phonenumber}");
                }
            }
        }

        public static void DisplayAllClient()
        {
            using(var db = new AppDbContext())
            {

                Console.WriteLine("Not Yet Implemented");
                /*
                foreach (var Client in db.Clients)
                {
                    Console.WriteLine($"Client {Client.ClientID}");
                    Console.WriteLine($"ClientName: {Client.ClientName}");
                    Console.WriteLine($"Phone Number: {Client.Phone}");
                }
                */
            }
        }

        public static void InputStudent()
        {
            string fname, lname, pnumber;
            //Take and store input for student variables.
            Console.WriteLine("Enter the Student's First Name.");
            fname = Console.ReadLine();

            Console.WriteLine("Enter the Student's Last Name.");
            lname = Console.ReadLine();

            Console.WriteLine("Enter the Student's Phone Number.");
            pnumber = Console.ReadLine();

            //Add new student data to database
            using(var db = new AppDbContext())
            {
                Student f = new Student()
                {
                    FirstName = fname,
                    LastName = lname,
                    Phonenumber = pnumber,
                    TeamID = 1,
                };

                db.Students.Add(f);
                db.SaveChanges();
            }
        }

        public static void InputClient()
        {
            Console.WriteLine("Not Yet Implemented");
            /* 
            string cname, pnumber;
            //Take and store input for student variables.
            Console.WriteLine("Enter the Client's Name.");
            cname = Console.ReadLine();

            Console.WriteLine("Enter the Client's Phone Number.");
            pnumber = Console.ReadLine();

            //Add new student data to database
            using(var db = new AppDbContext())
            {
                Client c = new Client()
                {
                    ClientID = 1,
                    ClientName = cname,
                    Phone = pnumber,
                    OrganizationID = 1,
                };

                db.Clients.Add(c);
            
                db.SaveChanges();
            }
            */
            
        }

        public static void UpdateStudent()
        {
            using(var db = new AppDbContext())
            {
                Console.WriteLine("Enter the First Name of the Student you would like to Change");

                string oldStudent = Console.ReadLine();

                try
                {
                    Student student = (from s in db.Students
                                where s.FirstName == oldStudent
                                select s).SingleOrDefault();

                    student.FirstName = "test";
                    Console.WriteLine("Enter the new information for the Updated Student");
                    
                    Console.Write("First Name: ");
                    string newFname = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string newLname = Console.ReadLine();
                    Console.Write("Phone Number: ");
                    string newPhone = Console.ReadLine();
                    
                    student.FirstName = newFname;
                    student.LastName = newLname;
                    student.Phonenumber = newPhone;
                    
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("No Student Information Found!!");
                }
                
            }
        }

        public static void SearchStudent()
        {
            using(var db = new AppDbContext())
            {
                
                Console.WriteLine("Enter the First Name of the Student you would like to find.");

                string findStudent = Console.ReadLine();

                try
                {
                    Student student = (from s in db.Students
                                    where s.FirstName == findStudent
                                    select s).SingleOrDefault();

                    Console.WriteLine($"Student: {student.StudentID}");
                    Console.WriteLine($"First Name: {student.FirstName}");
                    Console.WriteLine($"Last Name: {student.LastName}");
                    Console.WriteLine($"Phone Number: {student.Phonenumber}");
                }
                catch
                {
                    Console.WriteLine("Student not Found!");
                }
                

            }
        }
    }
}