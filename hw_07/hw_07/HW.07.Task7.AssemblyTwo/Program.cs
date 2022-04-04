using System;
using HW._07.Task7.AssemblyOne;


namespace HW._07.Task7.AssemblyTwo
{
    class Program
    {
        static void Main()
        {
            // Motorcycle moto2 = new Motorcycle();  //Internal class inaccessible in tne other project.
            Truck truck = new Truck();
            Console.WriteLine(truck.OdometerPublic);  //Access to public class (public property) in the other project.
            //Console.WriteLine(truck.VehicleUsageCalculateInternal(22, 33)); ///Inaccessible internal method.
            Bigtruck bigtruck = new Bigtruck();
            //Console.WriteLine(bigtruck.Distance); //Inaccessible internal property of Truck class.
            Console.WriteLine(Bigtruck.MaxWeight);
            Console.WriteLine(truck.Distance);  //Public property. Internal, protected internal property (from the other project) is inaccessible.
            Console.WriteLine(bigtruck.Distance); //Public property.
            Console.WriteLine(bigtruck.DistanceIntProt); //Public property for modification of internal protected field of Truck class in the other project.

        }
    }
}
