using System;

namespace HW._01.Casting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Implicit conversion");
            sbyte a = 4;
            short b = -100;
            int c = a + b;
            Console.WriteLine(c);

            c = b;
            Console.WriteLine(c);

            char symbol1 = 'z';
            int z = symbol1;
            Console.WriteLine(z);

            int x = 5, y = 12;
            double f = x - y;
            Console.WriteLine(f);

            byte sb = 125;
            byte bt1 = sb, bt2 = ++bt1;
            Console.WriteLine(bt2);

            Console.WriteLine("Explicit conversion");
            int a1 = 5;
            int b1 = 6;
            byte c1 = (byte)(a1 + b1);
            Console.WriteLine(c1);

            char ch1 = 'a';
            int t = (int)(ch1 + 5);
            char ch2 = (char)(t);
            Console.WriteLine(ch2);

            string str1 = Convert.ToString((char)(t + 10));
            Console.WriteLine(str1);

            int n1 = 5, n2 = 15;
            float f1 = Convert.ToSingle(n1) / Convert.ToSingle(n2);
            Console.WriteLine(f1);

            int n3 = Convert.ToInt32(f1 * 100);
            Console.WriteLine(n3);

            Console.WriteLine("Boxing and unboxing");
            int i1 = 123;
            object o1 = i1;
            int j1 = (int)(o1);
            Console.WriteLine(j1);

            char ch3 = 'w';
            object o2 = ch3;
            char c2 = (char)(o2);
            Console.WriteLine(c2);

            string str2 = "Hello!";
            object o3 = str2;
            string str3 = (string)(o3);
            Console.WriteLine(str3);

            byte b2 = 29;
            object o4 = b2;
            byte b3 = (byte)(o4);
            Console.WriteLine(b3);

            uint u1 = 255_255;
            object o5 = u1;
            uint u2 = (uint)(o5);
            Console.WriteLine(u2);
            Console.ReadKey();

        }
    }
}
