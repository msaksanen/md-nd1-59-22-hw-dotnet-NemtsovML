using System;

namespace HW._05.Quadratic.Formula
{
    class Program
    {
        static void Main()
        {
            double a,b,c,x1,x2,d; bool result;
   ToStart: Console.WriteLine("Input coefficients for quadratic equation ax^2+bx+c=0");
            Console.WriteLine("Use number decimal separator ',' or '.' according to your regional settings"); 

            Console.WriteLine("Input a");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out a);
                if (result == false)
                { 
                   Console.WriteLine("The coefficient a is incorrect. Would you like to continue? Type Y/N");
                   string? input2=Console.ReadLine();
                   bool result2 = char.TryParse(input2, out char yn);
                   if (result2==true & yn=='Y'|| yn=='y')
                       Console.WriteLine("Input correct coefficient a");
                   else goto ToEnd;
                }
            }
            while (result == false);

            Console.WriteLine("Input b");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out b);
                if (result == false)
                {
                    Console.WriteLine("The coefficient b is incorrect. Would you like to continue? Type Y/N");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct coefficient b");
                    else goto ToEnd;
                }
            }
            while (result == false);

            Console.WriteLine("Input c");
            do
            {
                string? input1 = Console.ReadLine();
                result = double.TryParse(input1, out c);
                if (result == false)
                {
                    Console.WriteLine("The coefficient c is incorrect. Would you like to continue? Type Y/N");
                    string? input2 = Console.ReadLine();
                    bool result2 = char.TryParse(input2, out char yn);
                    if (result2 == true & yn == 'Y' || yn == 'y')
                        Console.WriteLine("Input correct coefficient c");
                    else goto ToEnd;
                }
            }
            while (result == false);

            Console.WriteLine($"Your equation is {a}x^2+({b})x+({c})=0");

            if (b == 0 & c == 0)
            { x1 = 0;
              Console.WriteLine("The result is x=0");
              goto ToEnd;
            }
            
            if (b == 0)
            { if (c / a > 0)
                {
                    Console.WriteLine($"No roots of the equation: x^2=-({c})/({a}).");
                    goto ToEnd;
                }
                else 
                { 
                x1 = Math.Sqrt((-1) * c / a);
                x2 = (-1)*Math.Sqrt((-1) * c / a);
                Console.WriteLine($"The roots of the equation are: {x1} and {x2}");
                goto ToEnd;
                }
            }
           
            if (c == 0)
            {
                x1 = 0;
                x2 = (-1) * b / a;
                Console.WriteLine($"The roots of the equation are: {x1} and {x2}");
                goto ToEnd;
            }
            d = b * b - 4 * a * c; //Discriminant
            if (d < 0)
            {
                Console.WriteLine($"No roots of the equation: Discriminant < 0.");
                goto ToEnd;
            }

            if (d == 0)
            {
                x1 = (-1) * b /( 2 * a);
                Console.WriteLine($"The root of the equation is: {x1}.");
                goto ToEnd;
            }
                else 
                {
                x1 = ((-1) * b + Math.Sqrt(d)) / (2 * a);
                x2 = ((-1) * b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine($"The roots of the equation are: {x1} and {x2}");
            }


     ToEnd: Console.WriteLine("The program is finished. Would you like to start again? Type Y/N");
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
