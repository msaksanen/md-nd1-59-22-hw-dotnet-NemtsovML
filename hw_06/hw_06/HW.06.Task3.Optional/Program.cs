using System;
using System.Diagnostics;

namespace HW._06.Task3.Optional
{
    class Program
    {
        static void Main()
        {
            int temp, n, f, nr;
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
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine($"Input correct number (positive integer).");
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

            Console.WriteLine("Your one-dimension array:");

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }
           
            //The program counts items from [1] for user convenience.

            Console.WriteLine("Input position of the first item for reversion (positive integer).");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out f);
                if (!IscorrectInput || (f <= 0 || f >= n))
                {
                    Console.WriteLine("The position has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct position (positive integer).");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput || (f <= 0 || f >= n));

            Console.WriteLine("Input number of items for reversion (positive integer).");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out nr);
                if (!IscorrectInput || (nr < 0 || (f - 1 + nr) > n))
                {
                    Console.WriteLine("The number of items has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct number of items (positive integer).");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput || (nr <= 0 || (f - 1 + nr) > n));

            Console.WriteLine($"OK. Items from {f} to {f + nr - 1} will be resorted in reverse order.");

            stopwatch.Start();

            for (int i = 0; i + f - 1 < f + nr - 2 - i; i++) //Selected items of array reversion example. (MS-like functionality.)
            {
                temp = num[i + f - 1];
                num[i + f - 1] = num[f + nr - 2 - i];
                num[f + nr - 2 - i] = temp;
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

            Array.Reverse(num, f - 1, nr);

            stopwatch.Stop();
            long ts2 = stopwatch.ElapsedTicks;  // Gets the elapsed time in ticks (1 tick = 100 nanoseconds).
            stopwatch.Reset();

            Console.WriteLine("Re-reversed one-dimension array with Array.Reverse Method:");

            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

            Console.WriteLine($"Summary. Number of items in array: {n}.");
            Console.WriteLine($"Position of the first item for reversion: {f}.");
            Console.WriteLine($"Number of items for reversion: {nr}.");
            Console.WriteLine("RunTime of my Reverse Array Algo: " + ts1 + " ticks.");
            Console.WriteLine("RunTime of Array.Reverse Method: " + ts2 + " ticks.");

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
