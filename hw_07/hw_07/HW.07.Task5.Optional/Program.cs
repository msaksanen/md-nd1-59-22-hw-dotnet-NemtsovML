using System;

namespace HW._07.Task5.Optional
{
    class Program
    {
        static void Main()
        {
            int num1, num2;
            char c;
            bool result;
            DateTime dt = new DateTime();
            string input;
            string dateString = "05/01/1996";

            Console.WriteLine("Input integer number.");
            input = Console.ReadLine();
            num1 = int.Parse(input);

            Console.WriteLine("Input integer number again.");
            input = Console.ReadLine();
            result = int.TryParse(input, out num2);
            Console.WriteLine(num2);

            Console.WriteLine("Input char any (one) symbol.");
            input = Console.ReadLine();
            c = char.Parse(input);

            Console.WriteLine("Input char any (one) symbol again.");
            input = Console.ReadLine();
            result = char.TryParse(input, out c);
            Console.WriteLine(c);

            dt = DateTime.Parse(dateString);
            result = DateTime.TryParse(dateString, out dt);
            Console.WriteLine(dt);

            Console.WriteLine("Press any key to quit the application.");
            Console.ReadKey();
        }
    }
}
