using System;

namespace Buffteks
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student()
            {
                StudentID = 1,
                FirstName = "Alex",
                LastName = "McDonald",
                Phonenumber = "555-555-5555",
                
            };

            Client c = new Client()
            {
                ClientID = 1,
                ClientName = "Bob",
                Phone = "555-555-5555",
            };

            using(var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Students.Add(s);
                db.Client.Add(c);
                db.SaveChanges();
            }


        }
    }
}
