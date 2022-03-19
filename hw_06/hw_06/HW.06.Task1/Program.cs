using System;

namespace HW._06.Task1
{
    class Program
    {
        static void Main()
        {
            bool IscorrectInput;
            int n;
            Random rnd = new Random();

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

            int[] numr = new int[n]; //random array
            int[] numi = new int[n]; //user input array
            int[] nums = new int[n]; //pairwise sum of 2 arrays

            for (int i = 0; i < n; i++)
            {
                numr[i] = rnd.Next(0, 1000);
            }

            Console.WriteLine("Input integer numbers to fill one-dimension array");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Input item[{i + 1}]"); //The program counts items from [1] for user convenience.
                do
                {
                    string? input1 = Console.ReadLine();
                    IscorrectInput = int.TryParse(input1, out numi[i]);
                    if (!IscorrectInput)
                    {
                        Console.WriteLine($"The item[{i + 1}] has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                        string? input2 = Console.ReadLine();
                        bool result2 = char.TryParse(input2, out char yn);
                        if (result2 == true & yn == 'Y' || yn == 'y')
                            Console.WriteLine($"Input correct value for item[{i + 1}].");
                        else goto ToEnd;
                    }
                }
                while (!IscorrectInput);
            }

            Console.WriteLine("Three arrays - randomized, input and their pairwaise sum: ");
            for (int i = 0; i < n; i++)
            {
                nums[i] = numr[i] + numi[i];
                Console.WriteLine(numr[i] + " + " + numi[i] + " = " + nums[i]);
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
