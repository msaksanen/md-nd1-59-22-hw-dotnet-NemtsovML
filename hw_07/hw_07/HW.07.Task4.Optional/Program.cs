using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace HW._07.Task4.Optional
{
    class Program
    {
        //https://gist.github.com/donnaken15/04c50e77b1bbf41c3afa1fffe5ae2148
        // found using IDA 6.8 Pro

        // charmap loads a DLL named GetUName.dll
        // which has a selfnamed function and pulls
        // the name of a unicode character using an
        // int and loads the name into a string

        // in c++, it is used like
        // GetUName(int, LPWSTR *)

        [DllImport("GetUName.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetUName(int x, [MarshalAs(UnmanagedType.LPWStr)] string lpBuffer);

        // create string buffer to load name in (255 in case of large names, can be changed)
        public static string charactername = new string('*', 255);

        static void Main()
        {
            int s = -1; 
            int sym_incl = 0; 
            int count = 0;
            StringBuilder sb = new StringBuilder(""); //Self-expandable char array for invisible characters.
           
            StreamReader textReader = new StreamReader(@"D:\FindMe.txt", true); //Opens a stream for file reading from the path, detects encoding.
            string txtReadRes = textReader.ReadToEnd(); // Assigns all characters from the file stream till the end of file.

            textReader.Dispose(); //Realeses all resources used by TextReader.

            for (int i = 0; i < txtReadRes.Length; i++) //The cycle runs until counter "i" is less than total number of elements of the array.
            {
                if ((txtReadRes[i] >= 0 && txtReadRes[i] <= 31) || (txtReadRes[i] >= 127 && txtReadRes[i] <= 160)) //Looks for invisible control symbols.
                //if (CharUnicodeInfo.GetUnicodeCategory(txtReadRes[i]) == UnicodeCategory.Control)            //Alternative condition.
                {
                    for (int j = 0; j < sb.Length; j++)
                    {
                        if (sb[j] == txtReadRes[i]) sym_incl = 1; //If the symbol hasn't been occured earlier it will be appended to the Stringbuilder.
                        else sym_incl = 0;
                    }
                    if (sym_incl == 0) sb.Append(txtReadRes[i]);
                }
                sym_incl = 0;
            }

            for (int i = 0; i < sb.Length; i++)          //Seeks all invisible symbols in text, types it position and quantity.
            {
                for (int j = 0; j < txtReadRes.Length; j++)
                {
                    if (sb[i] == txtReadRes[j])
                    {
                        s = (int)txtReadRes[j];

                        if (count == 0)  //First occurence of invisible symbol.
                        {
                            GetUName(s, charactername);
                            // asteriks are still left in (* because names don't include
                            // any), simply cut the length so they aren't included
                            charactername = charactername.Substring(0, charactername.IndexOf('*') - 1);

                            Console.WriteLine($@"The symbol with code hex""{s:X4}"" dec ""{s:D4}"" is found.");
                            Console.WriteLine($"UnicodeCategory: {CharUnicodeInfo.GetUnicodeCategory(s)}");
                            Console.WriteLine($"Unicode Info Name: {charactername}");
                            Console.WriteLine($@"The first position of the symbol with code ""{s}"" is {j}");
                        }
                        else
                        {
                            Console.WriteLine($@"The position of the symbol with code ""{s}"" is {j}");
                        }
                        count++;
                    }
                    if (j == txtReadRes.Length - 1)
                    {
                        Console.WriteLine($@"Total number of occurencies of the symbol with code ""{s}"" is {count}.");
                        count = 0; s = -1;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
