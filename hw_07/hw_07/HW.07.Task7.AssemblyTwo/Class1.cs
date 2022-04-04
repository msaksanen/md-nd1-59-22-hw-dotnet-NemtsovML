using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._07.Task7.AssemblyOne;

namespace HW._07.Task7.AssemblyTwo
{
    //class Scooter2 : Motorcycle               //Motorcycle - inaccessible internal class.
    //{
    //    internal const byte MaxScootEngineVol = 50;
    //    int MaxScootSpeed = 50;

    //}
    class Bigtruck : Truck
    {
        internal const ushort MaxWeight = 30;
        public int DistanceIntProt
        {
            get
            {
                return _distanceIntProt;
            }
            set
            {
                _distanceIntProt = value;
            }
        }
    }
}
