using System;

namespace HW04.Game
{
    class Program
    {
        static void Main()
        { 
          Console.WriteLine("The program interprets direction of moving in the game.");
          Console.WriteLine("Type W (up), S (down), A (left), D (right) or X (exit application).");
          for (; ;)
          {
             char drct_std = default;
             string? input = Console.ReadLine();
             bool result = char.TryParse(input, out char drct);
             if (result) drct_std = char.ToLower(drct);
             switch (drct_std)
            {
                case 'w':
                    Console.WriteLine("It's moving up.");
                    break;
                case 's':
                    Console.WriteLine("It's moving down.");
                    break;
                case 'a':
                    Console.WriteLine("It's moving left.");
                    break;
                case 'd':
                    Console.WriteLine("It's moving right.");
                    break;
                case 'x':
                    Console.WriteLine("The program is finished. Press any key to quit the application.");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("It stays there.");
                    break;
            }
          }
        }
    }
}
