using System;
using System.Collections.Generic;
using System.Text;

namespace ExStructs
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Tony", "Allen", 32, Person.Genders.Male); Console.WriteLine(p.ToString());
        }
    }

    struct Person
    {
        string firstName;
        string lastName;
        int age;
        Genders gender;

        public Person(string _firstName, string _lastName, int _age, Genders _gender)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
            gender = _gender;
        }

        public override string ToString()
        {
            return firstName + " " + lastName + " (" + gender + "), age " + age;
        }

        public enum Genders { Male, Female };
    }
}
