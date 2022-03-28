using System;

namespace HW04.Operators2
{
    class Program
    {
        static void Main()
        {
            double n1, n2, ysum, sum; bool result;
        ToStart: Console.WriteLine("Input numbers for addition: sum = number1 + number2.");
            Console.WriteLine("Use number decimal separator ',' or '.' according to your regional settings.");

            Console.WriteLine("Input number1:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out n1);
                if (!result)
                {
                    Console.WriteLine("The number1 has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct value for number1:");
                    else goto ToEnd;
                }
            }
            while (!result);

            Console.WriteLine("Input number2:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out n2);
                if (!result)
                {
                    Console.WriteLine("The number2 has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct value for number2:");
                    else goto ToEnd;
                }
            }
            while (!result);

            Console.WriteLine($"Let's do a sum: ({n1}) + ({n2}) \nInput your sum:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out ysum);
                if (!result)
                {
                    Console.WriteLine("You have input value of incorrect data type. Would you like to input value of correct data type? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct value for your sum:");
                    else goto ToEnd;
                }
            }
            while (!result);

            sum = n1 + n2;
            if (ysum == sum)
            {
                Console.WriteLine($"Your result is correct: ({n1}) + ({n2}) = {sum} .");
            }
            else
            {
                Console.WriteLine($"Your result is incorrect: ({n1}) + ({n2}) != {ysum} . \n({n1}) + ({n2}) = {sum} .");
            }

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
