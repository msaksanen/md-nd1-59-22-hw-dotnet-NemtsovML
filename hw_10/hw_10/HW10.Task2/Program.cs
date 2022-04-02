using System;

namespace HW10.Task2
{
    class Program
    {
        static void Main()
        {
            Person person = new Person();
            person.Name = "John Smith";
            person.house = new SmallApartment();
            person.house.Area = 75;

            person.house.MainDoor.Color = "brown";

            House.Door door2 = default;               //Creates additional door and sets its color.
            person.house.MakeNewDoor(ref door2);
            door2.Color = "white";

            person.ShowData();
            Console.WriteLine($"Other doors' data:");
            door2.ShowData();

            Console.ReadKey();
        }
    }
}
