using System;

namespace HW._06.Task4
{
    class Program
    {
        static void Main()
        {
            int n;
            bool IscorrectInput;
        ToStart: Console.WriteLine("Input the highest number for new triangle (positive integer 1-100).");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out n);
                if (!IscorrectInput || (n <= 0 || n > 100))
                {
                    Console.WriteLine("The number has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine($"Input correct number (positive integer).");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput || (n <= 0 || n > 100));

            Console.WriteLine("Let's build new triangle.");

            for (int i = 0; i <= n; i++)
            {
                for (int x = 1; x <= i; x++) Console.Write("  ");
                for (int j = 1; j <= n - i; j++)
                {
                    if (i + 1 < 10)
                    {
                        Console.Write(" " + (i + 1) + "  "); //Additional space to keep symmetry.
                    }
                    else
                    {
                        Console.Write((i + 1) + "  ");
                    }
                }
                Console.WriteLine();
            }

     ToEnd: Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input3 = Console.ReadLine();
            bool result3 = char.TryParse(input3, out char yn1);
            if (result3 == true & yn1 == 'Y' || yn1 == 'y') goto ToStart;
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
            }
        }
    }
}
