using System;
using System.Text;

namespace HW._07.Task6
{
    class Program
    {
        static void Main()
        {
            int pos;
            StringBuilder sb = new StringBuilder("");
            string? input;

            Console.WriteLine(@"Input a line which contains at least 1 symbol of ""?"".");
            do
            {
                pos = -1;
                input = Console.ReadLine();
                for (int s = 0; s < input.Length && pos == -1; s++)
                {
                    if (input[s] == '?')                            //Looks for the first "?" in the line.
                    {
                        pos = s;                                   //Saves position of the first "?" .
                    }
                }
                if (pos == -1)
                {
                    Console.WriteLine(@"The line does not contain cat least 1 symbol of ""?"".");
                    Console.WriteLine("Would you like to input correct data and continue? Type Y/ N.");
                    ContinueVerify();
                }
            }
            while (pos == -1);

            for (int n = 0; n < input.Length; n++)
            {
                if (n < pos)
                {
                    if (!(input[n] == '.' || input[n] == '!'))
                    {
                        sb.Append(input[n]);
                    }
                }
                else if ((n > pos) && input[n] == ' ')
                {
                    sb.Append('_');
                }
                else sb.Append(input[n]);
            }

            Console.WriteLine($"Here it is modified line: \n{sb}");
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
