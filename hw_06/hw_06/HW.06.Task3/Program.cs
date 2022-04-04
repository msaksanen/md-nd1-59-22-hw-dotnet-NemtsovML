using System;
using System.Diagnostics;

namespace HW._06.Task3
{
    class Program
    {
        static void Main()
        {
            int temp, n;
            bool IscorrectInput;
            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

   ToStart: Console.WriteLine("Input number of items for new array (positive integer).");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out n);
                if (!IscorrectInput || (n <= 0))
                {
                    Console.WriteLine("The number has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct number (positive integer).");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput || (n <= 0));

            int[] num = new int[n]; //New array with selected number fo items.
            int l = num.Length;

            for (int i = 0; i < l; i++)
            {
                num[i] = rnd.Next(0, 1000);
            }

            Console.WriteLine("Your one-dimension array:"); //The program counts items from [1] for user convenience.

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

            stopwatch.Start();

            for (int i = 0; i <= l - i - 1; i++)
            {
                temp = num[i];
                num[i] = num[l - 1 - i];
                num[l - 1 - i] = temp;
            }

            stopwatch.Stop();
            long ts1 = stopwatch.ElapsedTicks;  // Gets the elapsed time in ticks (1 tick = 100 nanoseconds).
            stopwatch.Reset();


            Console.WriteLine("Reversed one-dimension array:");

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

            stopwatch.Start();

            Array.Reverse(num, 0, l);

            stopwatch.Stop();
            long ts2 = stopwatch.ElapsedTicks;  // Gets the elapsed time in ticks (1 tick = 100 nanoseconds).
            stopwatch.Reset();

            Console.WriteLine("Re-reversed one-dimension array with Array.Reverse Method:");

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

            Console.WriteLine("RunTime of my Reverse Array Algo: " + ts1 + " ticks.");
            Console.WriteLine("RunTime of Array.Reverse Method: " + ts2 + " ticks.");

     ToEnd: Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input3 = Console.ReadLine();
            //bool result3 = char.TryParse(input3, out char yn1);
            //if (result3 == true & yn1 == 'Y' || yn1 == 'y') goto ToStart;
            if (input3.Equals("Y", StringComparison.OrdinalIgnoreCase)) goto ToStart;
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
            }
        }
    }
}
