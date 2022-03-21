using System;

namespace HW._06.Task2
{
    class Program
    {
        static void Main()
        {
            int n1, p;
            bool IscorrectInput;
            int[] num = new int[10];

   ToStart: Console.WriteLine($"Input integer numbers to fill one-dimension array (1 - {num.Length}).");

            for (int i = 0; i < num.Length - 1; i++)
            {
                Console.WriteLine($"Input number[{i + 1}]"); //The program counts items from [1] for user convenience.
                do
                {
                    string? input1 = Console.ReadLine();
                    IscorrectInput = int.TryParse(input1, out num[i]);
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


            Console.WriteLine("Your one-dimension array:");

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

            Console.WriteLine("The array should include 10 items. Input missing item.");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out n1);
                if (!IscorrectInput)
                {
                    Console.WriteLine("The number has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct value for number:");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput);

            Console.WriteLine($"Input position in the array for missing item (1 - {num.Length}).");
            do
            {
                string? input1 = Console.ReadLine();
                IscorrectInput = int.TryParse(input1, out p);
                if (!IscorrectInput || !(p > 0 && p <= num.Length))
                {
                    Console.WriteLine("The position has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine($"Input correct value for position (1 - {num.Length}).");
                    else goto ToEnd;
                }
            }
            while (!IscorrectInput || !(p > 0 && p <= num.Length));

            for (int i = num.Length; i > p; i--)
            {
                num[i - 1] = num[i - 2]; //Moves all items righter to free selected position. 
            }

            num[p - 1] = n1; //Item insertion.

            Console.WriteLine("Your one-dimension array with new item:");

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"Item[{i + 1}] " + num[i]);
            }

     ToEnd: num[num.Length - 1] = 0; //Zeroing last item for new program cycle.
            Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
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
