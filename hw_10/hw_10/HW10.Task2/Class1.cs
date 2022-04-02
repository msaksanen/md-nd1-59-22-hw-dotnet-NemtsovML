using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task2
{
    public class House
    {
        public virtual float Area { get; set; } = 200;
        public Door MainDoor { get; set; } = new Door(); //Access to door, the next property of a house.

        public House() { Area = 200; }

        public House(float area) { Area = 200; }

        public void ShowData()
        {
            Console.WriteLine($"I am a house, my area is {Area} m2.");
            Console.WriteLine($"I am a door, my color is {MainDoor.Color}.");
        }

        public void GetDoor(Door door)
        {
            door.ShowData();
        }

        //public Door MakeNewDoor(ref House.Door doorname)
        //{
        //    doorname = new Door();
        //    return doorname;
        //}

        public class Door //Nested Class
        {
            public string Color { get; set; } = "underfined";

            public void ShowData()
            {
                Console.WriteLine($"I am a door, my color is {this.Color}.");
            }
        }
    }
    class SmallApartment : House
    {
        public override float Area { get; set; } = 50;
    }
    public class Person
    {
        public string Name { get; set; } = "underfined";
        public House house;

        public void ShowData()
        {
            Console.WriteLine($"I am a person. My name is {this.Name}.");
            Console.WriteLine("The data of my house and its main door.");
            house.ShowData();
        }
    }
}
