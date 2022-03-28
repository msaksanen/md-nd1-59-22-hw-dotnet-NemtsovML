using System;

namespace HW04.Operators4
{
    class Program
    {
        static void Main()
        {
            double n1, n2, sum, sub, mult, div, yres; bool result; char sgn;
   ToStart: Console.WriteLine("Input numbers for addition (result = number1 + number2) or subtraction (result = number1 - number2)");
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

            Console.WriteLine("Input type of operation: (+) , (-), (*) or (/).");
            do
            {
                string? input1 = Console.ReadLine();
                result = char.TryParse(input1, out sgn);
                if (!result || !(sgn == '+' || sgn == '-' || sgn == '*' || sgn == '/'))
                {
                    Console.WriteLine("You have input incorrect operator. Would you like to input correct operator and continue? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct type of operation: (+) , (-), (*) or (/).");
                    else goto ToEnd;
                }
            }
            while (!result || !(sgn == '+' || sgn == '-' || sgn == '*' || sgn == '/'));

            if (sgn == '/' & n2 ==0)
            {
                Console.WriteLine($"Cannot divide by zero: ({n1}) / ({n2})");
                Console.WriteLine("Please restart the program for correct calculation.");
                goto ToEnd;
            }

            Console.WriteLine("Input your result:");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out yres);
                if (!result)
                {
                    Console.WriteLine("You have input value of incorrect data type. Would you like to input value of correct data type? Type Y/N.");
                    string? input2 = Console.ReadLine();
                    //bool result2 = char.TryParse(input2, out char yn);
                    //if (result2 == true & yn == 'Y' || yn == 'y')
                    if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Input correct value for your result:");
                    else goto ToEnd;
                }
            }
            while (!result);

            switch (sgn)
            {
                case '+':
                    Console.WriteLine($"Let's do a sum: ({n1}) + ({n2})");
                    goto ToSum;
                case '-':
                    Console.WriteLine($"Let's do a subtraction: ({n1}) - ({n2})");
                    goto ToSub;
                case '*':
                    Console.WriteLine($"Let's do a multiplication: ({n1}) * ({n2})");
                    goto ToMulti;
                case '/':
                    Console.WriteLine($"Let's do a division: ({n1}) / ({n2})");
                    goto ToDiv;
                default:
                    Console.WriteLine("Something goes wrong ((.");
                    goto ToEnd;
            }

     ToDiv: div = n1 / n2;
            if (yres == div)
            {
                Console.WriteLine($"Your division is correct: ({n1}) / ({n2}) = {div}.");
                goto ToEnd;
            }
            else if (div > yres)
            {
                Console.WriteLine($"Your result is incorrect. It is less than correct division: ({div})>({yres})");
                Console.WriteLine($"({n1}) / ({n2}) != {yres}. \n({n1}) / ({n2}) = {div}");
                goto ToEnd;
            }
            else
            {
                Console.WriteLine($"Your result is incorrect. It is larger than correct division: ({div})<({yres})");
                Console.WriteLine($"({n1}) / ({n2}) != {yres}. \n({n1}) / ({n2}) = {div}");
                goto ToEnd;
            }

   ToMulti: mult = n1 * n2;
            if (yres == mult)
            {
                Console.WriteLine($"Your multiplication is correct: ({n1}) * ({n2}) = {mult}.");
                goto ToEnd;
            }
            else if (mult > yres)
            {
                Console.WriteLine($"Your result is incorrect. It is less than correct multiplication: ({mult})>({yres})");
                Console.WriteLine($"({n1}) * ({n2}) != {yres}. \n({n1}) * ({n2}) = {mult}");
                goto ToEnd;
            }
            else
            {
                Console.WriteLine($"Your result is incorrect. It is larger than correct multiplication: ({mult})<({yres})");
                Console.WriteLine($"({n1}) * ({n2}) != {yres}. \n({n1}) * ({n2}) = {mult}");
                goto ToEnd;
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
