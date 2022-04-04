using System;

namespace HW._07.Task2
{
    class Program
    {
        static void Main()
        {
            string? input = default;
            string div = " ";
            string div2 = "  ";

            Console.WriteLine(@"Input a line of words. Please divide words with single space "" "".");
            do
            {
                input = Console.ReadLine();
                if (!input.Contains(div))
                {
                    Console.WriteLine("The line does not contain space. Would you like to input correct data and continue? Type Y/N.");
                    ContinueVerify();
                }
                if (input.Contains(div2)) input = input.Replace(div2, div); //Removes duplicate spaces.
            }
            while (!input.Contains(div));

            DeleteLongestWord(input);

            ChangeLongestShortestWord(input);

            CountLettersPunctuation(input);

            SortWordsDescend(input);

            EndApplication();
        }
        static void ContinueVerify()
        {
            string? input2 = Console.ReadLine();
            //bool result2 = char.TryParse(input2, out char yn);
            //if (result2 == true & yn == 'Y' || yn == 'y')
            if (input2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"Input line with correct dividing symbols.");
            else EndApplication();
        }
        static void DeleteLongestWord(string text)
        {
            string[] lines = text.Split(' ');
            string longest = lines[0];

            for (int i = 1; i < lines.Length; i++)
            {
                if (longest.Length < lines[i].Length) longest = lines[i];
            }
            text = text.Replace(longest, "");
            Console.WriteLine("The longest word is deleted: " + text);
        }
        static void ChangeLongestShortestWord(string text)
        {
            string[] lines = text.Split(' ');
            string longest = lines[0];
            string shortest = lines[0];
            string temp;
            int ind_l = 0, ind_sh = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (longest.Length < lines[i].Length)
                {
                    longest = lines[i]; ind_l = i;
                }
                if (shortest.Length > lines[i].Length)
                {
                    shortest = lines[i]; ind_sh = i;
                }
            }

            //Changes positions of the shortest and the longest words.
            temp = lines[ind_l];
            lines[ind_l] = lines[ind_sh];
            lines[ind_sh] = temp;

            Console.WriteLine("The positions of the shortest and the longest words are changed.");

            foreach (string str in lines)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
        static void CountLettersPunctuation(string text)
        {
            int count_let = 0;
            int count_punct = 0;
            int symb;

            foreach (char ch in text)
            {
                symb = (char)ch;
                switch (symb)
                {
                    case >= 65 when (symb<= 90):
                        count_let++; break;
                    case >= 97 when (symb <= 122):
                        count_let++; break;
                    case 33:
                    case 34:
                    case 58:
                    case 59:
                    case 63:
                        count_punct++; break;
                    case >= 39 when (symb <= 41):
                        count_punct++; break;
                    case >= 44 when (symb <= 46):
                        count_punct++; break;
                    case >= 1040 when (symb <= 1103):
                        count_let++; break;
                }
                //if (ch >= 65 && ch <= 90)  count_let++;                   //Letters A-Z.
                //if (ch >= 97 && ch <= 122) count_let++;                  //Letters a-z.
                //if (ch == 33 || ch == 34)  count_punct++;                 //Symbols ! "
                //if (ch >= 39 && ch <= 41)  count_punct++;                 //Symbols ' ( )
                //if (ch >= 44 && ch <= 46)  count_punct++;                 //Symbols , . -
                //if (ch == 58 || ch == 59 || ch == 63) count_punct++;     //Symbols : ; ?
                //if (ch >= 1040 && ch <= 1103) count_let++;               //Letters А-Я/а-я.
            }
            Console.WriteLine($"The number of letters is {count_let}. \nThe number of punctuation symbols is:{count_punct}.");
        }
        static void SortWordsDescend(string text)
        {
            string[] lines = text.Split(' ');
            int l = lines.Length;
            string temp;

            for (int i = 0; i < l - 1; i++)
            {
                for (int j = i + 1; j < l; j++)
                {
                    if (lines[i].Length < lines[j].Length)
                    {
                        temp = lines[i];
                        lines[i] = lines[j];
                        lines[j] = temp;
                    }
                }
            }

            Console.WriteLine("The line is resorted in descending order by the length of words.");

            foreach (string str in lines)
            {
                Console.WriteLine(str);
            }

        }
        static void EndApplication()
        {
            Console.WriteLine("The program is finished. Would you like to start again? Type Y/N.");
            string? input3 = Console.ReadLine();
            //bool result3 = char.TryParse(input3, out char yn1);
            //if (result3 == true & yn1 == 'Y' || yn1 == 'y') Main();
            if (input3.Equals("Y", StringComparison.OrdinalIgnoreCase)) Main();
            else
            {
                Console.WriteLine("Press any key to quit the application.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
