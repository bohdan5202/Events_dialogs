using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public string City { get; set; }

        public Person(string firstName, string lastName, int yearOfBirth, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            City = city;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, date: {YearOfBirth}, city: {City}";
        }
    } 
}
