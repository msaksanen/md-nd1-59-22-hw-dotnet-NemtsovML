using System;

namespace HW04.Operators4
{
    class Program
    {
        static void Main()
        {
            double n1, n2, sum, sub, yres; bool result; char sgn;
        ToStart: Console.WriteLine("Input numbers for addition (result = number1 + number2) or subtraction (result = number1 - number2)");
            Console.WriteLine("Use number decimal separator ',' or '.' according to your regional settings.");

            Console.WriteLine("Input number1:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out n1);
                if (result == false)
                {
                    Console.WriteLine("The number1 has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct value for number1:");
                    else goto ToEnd;
                }
            }
            while (result == false);

            Console.WriteLine("Input number2:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out n2);
                if (result == false)
                {
                    Console.WriteLine("The number2 has incorrect value. Would you like to input correct data and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct value for number2:");
                    else goto ToEnd;
                }
            }
            while (result == false);

            Console.WriteLine("Input type of operation: (+) or (-)");
            do
            {
                string? input1 = Console.ReadLine();
                result = char.TryParse(input1, out sgn);
                if (result == false || !(sgn == '+' || sgn == '-'))
                {
                    Console.WriteLine("You have input incorrect operator. Would you like to input correct operator and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct type of operation: (+) or (-):");
                    else goto ToEnd;
                }
            }
            while (result == false || !(sgn == '+' || sgn == '-'));

            Console.WriteLine("Input your result:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out yres);
                if (result == false)
                {
                    Console.WriteLine("You have input value of incorrect data type. Would you like to input value of correct data type? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct value for your result:");
                    else goto ToEnd;
                }
            }
            while (result == false);

            if (sgn == '+')
            {
                Console.WriteLine($"Let's do a sum: ({n1}) + ({n2})");
                goto ToSum;
            }
            else
            {
                Console.WriteLine($"Let's do a subtraction: ({n1}) - ({n2})");
                goto ToSub;
            }

        ToSub: sub = n1 - n2;
            if (yres == sub)
            {
                Console.WriteLine($"Your subtraction is correct: ({n1}) - ({n2}) = {sub}.");
                goto ToEnd;
            }
            else if (sub > yres)
            {
                Console.WriteLine($"Your result is incorrect. It is less than correct subtraction: ({sub})>({yres})");
                Console.WriteLine($"({n1}) - ({n2}) != {yres}. \n({n1}) - ({n2}) = {sub}");
                goto ToEnd;
            }
            else
            {
                Console.WriteLine($"Your result is incorrect. It is larger than correct subtraction: ({sub})<({yres})");
                Console.WriteLine($"({n1}) - ({n2}) != {yres}. \n({n1}) - ({n2}) = {sub}");
                goto ToEnd;
            }

        ToSum: sum = n1 + n2;
            if (yres == sum)
            {
                Console.WriteLine($"Your sum is correct: ({n1}) + ({n2}) = {sum}.");
            }
            else if (sum > yres)
            {
                Console.WriteLine($"Your result is incorrect. It is less than correct sum: ({sum})>({yres})");
                Console.WriteLine($"({n1}) + ({n2}) != {yres}. \n({n1}) + ({n2}) = {sum}");
            }
            else
            {
                Console.WriteLine($"Your result is incorrect. It is larger than correct sum: ({sum})<({yres})");
                Console.WriteLine($"({n1}) + ({n2}) != {yres}). \n({n1}) + ({n2}) = {sum}");
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
