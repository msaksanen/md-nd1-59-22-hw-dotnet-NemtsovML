using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task1
{
    class Person
    {
        public int Age { get; set; } = 20;
        public void SetAge(ref int n)
        {
            this.Age = n;
            Console.WriteLine($"The age is set : {n} years.");
        }
        public void Greet()
        {
            Console.WriteLine($"Hello! I'm a {this.GetType().Name}");
        }
    }
    class Student : Person
    {
        public void GoToClasses()
        {
            Console.WriteLine("I’m going to class.");
        }
        public void ShowAge()
        {
            Console.WriteLine($"My age is: {this.Age} years old.");
        }
    }
    class Teacher : Person
    {
        public void Explain()
        {
            Console.WriteLine("Explanation begins.");
        }
    }
}
