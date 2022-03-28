using System;

namespace HW._07.Task1
{
    class Program
    {
        static void Main()
        {
            string? input = default;
            char div = ';';

            Console.WriteLine(@"Input a poem in one line. Please divide original lines with "";"" symbol.");
            do
            {
                input = Console.ReadLine();
                if (!input.Contains(div))
                {
                    Console.WriteLine("The line does not contain correct dividing symbols. Would you like to input correct data and continue? Type Y/N.");
                    ContinueVerify();
                }
            }
            while (!input.Contains(div));

            string[] lines = input.Split(div);

            Console.WriteLine("Here it is your modified poem.");

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('O', 'A'); //Latin letters.
                lines[i] = lines[i].Replace('o', 'A'); //Latin letters.
                lines[i] = lines[i].Replace('О', 'А'); //Cyrillic letters.
                lines[i] = lines[i].Replace('о', 'А'); //Cyrillic letters.
                Console.WriteLine(lines[i]);
            }

            EndApplication();
        }
        static void ContinueVerify()
        {
            string? input2 = Console.ReadLine();
            //bool result2 = char.TryParse(input2, out char yn);
            //if (result2 == true & yn == 'Y' || yn == 'y')
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"Input line with correct dividing symbols.");
            else EndApplication();
        }
        static void EndApplication()
        {
            Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input3 = Console.ReadLine();
            //bool result3 = char.TryParse(input3, out char yn1);
            //if (result3 == true & yn1 == 'Y' || yn1 == 'y') Main();
            if (input3.Equals("Y", StringComparison.OrdinalIgnoreCase)) Main();
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}

