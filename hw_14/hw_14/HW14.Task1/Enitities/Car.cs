using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14.Task1.Enitities
{
    public class Car : Transport
    {
        //public Guid Id { get; set; } = Guid.NewGuid();

        //public string Manufacturer { get; set; }

        //public string Model { get; set; }

        //public string Name { get; set; }

        //public int Odometer { get; set; }

        //public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            string date = ReleaseDate.Year.ToString();  //I use VS2019.

            return "Car. Manufacturer: " + Manufacturer + ". Model: " + Model + ". Name: " + Name + ". ReleaseDate: " + date + ". ID: " + Id;
        }
    }

}
