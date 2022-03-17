using System;

namespace HW04.Birthday
{
    class Program
    {
        static void Main()
        {
            bool result;int br_month, cur_month, br_yr, cur_yr, age;
   ToStart: Console.WriteLine("The program counts an age of a person.");

            Console.WriteLine("Please input number of the current month (1-12).");
            do
            {
                string? input1 = Console.ReadLine();
                result = int.TryParse(input1, out cur_month);
                if (!result || (cur_month > 12 || cur_month == 0))
                {
                    Console.WriteLine("The number of month has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2) yn = char.ToLower(yn);
                    if (result2 & yn == 'y')
                        Console.WriteLine("Input correct value of the month:");
                    else goto ToEnd;
                }
            }
            while (!result || (cur_month > 12 || cur_month == 0));

            Console.WriteLine("Please input current year (for calculation) in XXXX format (-2200 BC; 2200 AD).");
            do
            {
                string? input1 = Console.ReadLine();
                result = int.TryParse(input1, out cur_yr);
                if (!result || (cur_yr > 2200 ||cur_yr < -2200 )) //Some people lived BC )).
                {
                    Console.WriteLine("The number of the year has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2) yn = char.ToLower(yn);
                    if (result2 & yn == 'y')
                        Console.WriteLine("Input correct value of the year:");
                    else goto ToEnd;
                }
            }
            while (!result || (cur_yr > 2200 || cur_yr < -2200));

            Console.WriteLine("Please input number of a birthday month (1-12) of a person.");
            do
            {
                string? input1 = Console.ReadLine();
                result = int.TryParse(input1, out br_month);
                if (!result ||(br_month>12|| br_month==0))
                {
                    Console.WriteLine("The number of month has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2) yn = char.ToLower(yn);
                    if (result2 & yn == 'y')
                        Console.WriteLine("Input correct value of the month:");
                    else goto ToEnd;
                }
            }
            while (!result || (br_month > 12 || br_month == 0));

            Console.WriteLine("Please input a birth year of a person in XXXX format (-2200 BC; 2200 AD).");
            do
            {
                string? input1 = Console.ReadLine();
                result = int.TryParse(input1, out br_yr);
                if (result & (br_yr < 2200 & br_yr > -2200) & (cur_yr < br_yr))
                {
                    Console.WriteLine("You have input incorrect data: birth year > current (calculation) year.");
                    Console.WriteLine("Please restart the program for correct calculation.");
                    goto ToEnd;
                }
                if (!result || (br_yr > 2200 || br_yr < -2200) || (cur_yr<br_yr))
                {
                    Console.WriteLine("The number of the year has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2) yn = char.ToLower(yn);
                    if (result2 & yn == 'y')
                        Console.WriteLine("Input correct value of the year:");
                    else goto ToEnd;
                }
            }
            while (!result || (br_yr > 2200 || br_yr < -2200) || (cur_yr < br_yr));

            age = cur_yr - br_yr-1;

            if (cur_month >= br_month) ++age;
            Console.WriteLine($"Age of a person is (was) {age} years.");

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
