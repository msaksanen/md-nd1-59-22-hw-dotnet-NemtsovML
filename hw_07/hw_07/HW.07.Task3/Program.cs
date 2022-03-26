using System;
using System.Text;

namespace HW._07.Task3
{
    class Program
    {
        static void Main()
        {   //The first variant was implemented with strings. It's commented. 
            //The second variant uses StringBuilder.
            int sign_count, pos;
            //string? num1, num2;
            StringBuilder num1 = new StringBuilder("");
            StringBuilder num2 = new StringBuilder("");
            string snum1, snum2;
            char sign;
            double result;

            Console.WriteLine(@"Input a line which contains at least 2 numbers and one arythmetic sign between: ""+"", ""-"", ""*"" or ""/"" .");
            do
            {
                sign_count = 0;
                pos = -1;            //Sign position.
                num1.Clear();
                num2.Clear();
                //num1 = string.Empty;
                //num2 = string.Empty;
                sign = default;

                string? input = Console.ReadLine();
                for (int s = 0; s < input.Length; s++)
                {
                    if (input[s] == '+' || input[s] == '-' || input[s] == '*' || input[s] == '/')
                    {
                        sign_count++;
                        pos = s;                                   //Saves position of the sign.
                        sign = input[s];                           //Saves the sign.
                    }
                }

                if (sign_count == 1 && (pos != 0 && pos != input.Length))
                {
                    for (int n = 0; n < input.Length; n++)
                    {
                        if (input[n] >= 48 && input[n] <= 57)     //0-9 numbers in unicode.
                        {
                            if (n < pos)
                            {
                                // num1 += input[n];
                                num1.Append(input[n]);
                            }

                            else if (n > pos)
                            {
                                // num2 += input[n];
                                num2.Append(input[n]);
                            }
                        }
                    }
                }
                if (sign_count != 1 || num1.ToString() == string.Empty || num2.ToString() == string.Empty)
                // if (sign_count != 1 || num1 == string.Empty || num2 == string.Empty)
                {
                    Console.WriteLine("The line does not contain correct symbols: at least 2 numbers and one arythmetic sign between. \nWould you like to input correct data and continue? Type Y/N.");
                    ContinueVerify();
                }
                if (sign_count == 1 && (num2.ToString() == "0" && sign == '/'))
                // if (sign_count == 1 && num2 == "0" && sign=='/')
                {
                    Console.WriteLine("Incorrect data: division by zero. \nWould you like to input correct data and continue? Type Y/N.");
                    sign_count = -1;
                    ContinueVerify();
                }
            }
            //while (sign_count != 1 || num1 == string.Empty || num2 == string.Empty);
            while (sign_count != 1 || num1.ToString() == string.Empty || num2.ToString() == string.Empty);

            Console.WriteLine($"OK. Lets's {num1} {sign} {num2}");
            // snum1=num1;
            // snum2=num2;
            snum1 = num1.ToString();
            snum2 = num2.ToString();

            switch (sign)
            {
                case '+':
                    result = Convert.ToDouble(snum1) + Convert.ToDouble(snum2);
                    Console.WriteLine($"{snum1} + {snum2} = {result}");
                    break;
                case '-':
                    result = Convert.ToDouble(snum1) - Convert.ToDouble(snum2);
                    Console.WriteLine($"{snum1} - {snum2} = {result}");
                    break;
                case '*':
                    result = Convert.ToDouble(snum1) * Convert.ToDouble(snum2);
                    Console.WriteLine($"{snum1} * {snum2} = {result}");
                    break;
                case '/':
                    result = Convert.ToDouble(snum1) / Convert.ToDouble(snum2);
                    Console.WriteLine($"{snum1} / {snum2} = {result}");
                    break;
            }

            EndApplication();
        }
        static void ContinueVerify()
        {
            string? input2 = Console.ReadLine();
            bool result2 = char.TryParse(input2, out char yn);
            if (result2 == true & yn == 'Y' || yn == 'y')
                Console.WriteLine($"Input line with correct symbols.");
            else EndApplication();
        }
        static void EndApplication()
        {
            Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input3 = Console.ReadLine();
            bool result3 = char.TryParse(input3, out char yn1);
            if (result3 == true & yn1 == 'Y' || yn1 == 'y') Main();
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
            }
        }
    }
}
