using System;

namespace Buffteks
{


    public class Student
    {
        //pk
        public int StudentID { get; set; }

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string Phonenumber {get;set;}

        public int TeamID {get; set;}

        public Team Team {get; set;}

    }

}