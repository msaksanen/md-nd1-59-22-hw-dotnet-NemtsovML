using System;

namespace HW04.Loops
{
    class Program
    {
        static void Main()
        { char ul_std=default; int l,f;
            Console.WriteLine("The program types English alphabet in a reverse order.");
   ToStart: Console.WriteLine("Would you like upper or lower case letters? Type U/L.");
            string? input = Console.ReadLine();
            bool result = char.TryParse(input, out char ul);
            if (result) ul_std = char.ToLower(ul);
            switch (ul_std)
            {
                case 'u':
                    l = 90; f = 65; // Letters Z ='90' and A ='65'.
                    Console.WriteLine("Let's type upper case letters.");
                    break;
                case 'l':
                    l = 122; f = 97; // Letters z ='90' and a ='65'.
                    Console.WriteLine("Let's type lower case letters.");
                    break;
                default:
                    l = 122; f = 97; // Letters z ='90' and a ='65'
                    Console.WriteLine("OK. Let's type lower case letters.");
                    break;
            }
 
            for (int i = l; i >= f; i--)
            {
                char c = (char) i;
                Console.WriteLine(c);
            }
            Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input2 = Console.ReadLine();
            //bool result2 = char.TryParse(input2, out char yn1);
            //if (result2 & yn1 == 'Y' || yn1 == 'y') goto ToStart;
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase)) goto ToStart;
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
            }
        }
    }
}
