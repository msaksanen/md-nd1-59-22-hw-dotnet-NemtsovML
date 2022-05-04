using System;

namespace HW10.Task1
{
    class Program
    {
        static void Main()
        {
            Person person = new Person();
            person.Greet();

            Student student = new Student();
            int age = 21;
            student.SetAge(ref age);
            student.Greet();
            student.ShowAge();

            Teacher teacher = new Teacher();
            teacher.Age = 30;
            teacher.Greet();
            teacher.Explain();

            Console.ReadKey();
        }
    }
}
