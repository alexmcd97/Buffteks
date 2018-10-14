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

            Client g = new Client()
            {
                ClientID = 1,
                ClientName = "Ronald McDonald",
                Phone = "555-555-5556",
                Organization = new Organization {OrganizationID = 1, OrgName = "McDonald's"}
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
                
                /*
                if (!db.Clients.Any())
                {
                db.Clients.Add(g);
                Console.WriteLine("Database Seeded.");
                }
                */
                db.SaveChanges();
                }
               
            }

            while(true)
            {
                //Program Menu Loop
                Console.WriteLine(
                "\nPress Y to input student data, \nUS to Update a Student's Data, \nS to Search for a Specific Student's Data, \nV to View ALL Student data, \nX to Exit.");
                string test = Console.ReadLine();
                if(test == "Y")
                {
                    Commands.InputStudent();
                }
                else if (test == "V")
                {
                    Commands.DisplayAllStudent();
                }
                else if (test == "ZC")
                {
                    Commands.DisplayAllClient();
                }
                else if (test == "C")
                {
                    Commands.InputClient();
                }
                else if (test == "S")
                {
                    Commands.SearchStudent();
                }
                else if (test == "US")
                {
                    Commands.UpdateStudent();
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
