using System;

namespace HW._02.Types
{
    class Program
    {
        static void Main()
        {
            sbyte s1 = 120;
            System.SByte s2 = 120;
            Console.WriteLine($"sbyte {s1}  s1 {s1.GetType()}  s2 {s2.GetType()} ") ;

            short sh1 = -200;
            System.Int16 sh2 = -200;
            Console.WriteLine($"short {sh1}  sh1 {sh1.GetType()}  sh2 {sh2.GetType()} ");

            int i1 = 15200;
            System.Int32 i2 = 15200;
            Console.WriteLine($"int {i1}  i1 {i1.GetType()}  i2 {i2.GetType()} ");

            long l1 = 11120;
            System.Int64 l2 = 11120;
            Console.WriteLine($"long {l1}  l1 {l1.GetType()}  l2 {l2.GetType()} ");

            byte b1 = 250;
            System.Byte b2 = 250;
            Console.WriteLine($"byte {b1}  b1 {s1.GetType()}  b2 {b2.GetType()} ");

            ushort u1 = 65_000;
            System.UInt16 u2 = 65_000;
            Console.WriteLine($"ushort {u1}  u1 {u1.GetType()}  u2 {u2.GetType()} ");

            char ch1 ='z';
            System.Char ch2 = 'z';
            Console.WriteLine($"char {ch1}  ch1 {ch1.GetType()}  ch2 {ch2.GetType()} ");

            uint ui1 = 120_234_233;
            System.UInt32 ui2 = 120_234_233;
            Console.WriteLine($"uint {ui1}  ui1 {ui1.GetType()}  ui2 {ui2.GetType()} ");

            ulong ul1 = 120_222_222_222;
            System.UInt64 ul2 = 120_222_222_222;
            Console.WriteLine($"ulong {ul1}  ul1 {ul1.GetType()}  ul2 {ul2.GetType()} ");

            float f1 = 120.25f;
            System.Single f2 = 120.25f;
            Console.WriteLine($"float {f1}  f1 {f1.GetType()}  f2 {f2.GetType()} ");

            double d1 = 120.2534;
            System.Double d2 = 120.2534;
            Console.WriteLine($"double {d1}  d1 {d1.GetType()}  d2 {d2.GetType()} ");

            decimal dc1 = 120.25m;
            System.Decimal dc2 = 120.25m;
            Console.WriteLine($"decimal {dc1}  dc1 {dc1.GetType()}  dc2 {dc2.GetType()} ");

            string str1 = "Have a good day!";
            System.String str2 = "Have a good day!";
            Console.WriteLine($"string {str1}  str1 {str1.GetType()}  str2 {str2.GetType()} ");

            object o1 = "Object C#";
            System.Object o2 = 1245.2;
            Console.WriteLine($"object type  o1 {o1}  {o1.GetType()}  o2 {o2} {o2.GetType()} ");
            Console.ReadKey();
        }
    }
}
