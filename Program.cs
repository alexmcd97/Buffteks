using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Buffteks
{
    class Program
    {
        static void Main(string[] args)
        {
            //add test data
            Student s = new Student()
            {
                StudentID = 1,
                FirstName = "Alex",
                LastName = "McDonald",
                Phonenumber = "555-555-5555",
                Team = new Team { TeamName = "Potato"}
                
            };


            using(var db = new AppDbContext())
            {
                //Check if Database exists.
                if (!(db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Console.WriteLine("Database Created.");
                //check if Empty
                if (!db.Students.Any())
                {
                db.Students.Add(s);
                Console.WriteLine("Database Seeded.");
                }
                db.SaveChanges();
                }
               
            }

            while(true)
            {
                //Program Menu Loop
                Console.WriteLine("Press Y to input student data, X to Exit, Z to View Student data.");
                string test = Console.ReadLine();
                if(test == "Y")
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
                else if (test == "Z")
                {
                    //Display all current student data
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
                else if (test == "X")
                {
                    break; //Program Exit
                }
                else
                {
                    // Input Validation
                    Console.WriteLine("Invalid Input! Capital X, Y or Z only!");
                }
                
            }
        }

    }
}
