using System;

namespace HW._07.Task7.AssemblyOne
{
    class Program
    {
        static void Main()
        {
            Motorcycle moto = new Motorcycle();

            Console.WriteLine(moto);
            Console.WriteLine(Motorcycle.MaxMotoSpeedInternal);    //Access to internal const.
             //Console.WriteLine(Motorcycle.MaxSpeedPrivate);      //Inaccessible private constant.
             //Console.WriteLine(moto._vinNumber);                 //Inaccessible private field.
            Console.WriteLine(moto.VinNumberInternal);            //Access to private protected string via internal property.
             //Console.WriteLine(moto.VinNumberPrivate);          //Inaccessible private property.
             //Console.WriteLine(moto.VinNumberPrivateProtect);   //Inaccessible private property.
            Console.WriteLine(moto._vinNumberProtect);          // protected internal string
            Console.WriteLine(moto.OdometerPublic);
            Console.WriteLine(moto.VehicleUsageCalculateInternal(22, 33));

            Scooter scooter = new Scooter();                    //class Scooter:Motorcycle
            Console.WriteLine(Scooter.MaxMotoSpeedInternal);     //Access to internal const of parental class.
            Console.WriteLine(scooter.VinNumberInternal);       //Access to private protected string via internal property of parental class.
            //Console.WriteLin(scooter.VinNumberPrivateProtect); //Inaccessible private property.
            //Console.WriteLine(Motorcycle.MaxScootEngineVol);   //Inaccessible constant of another class.
            Console.WriteLine(scooter._distance);                 //Inherited internal field.
            Console.WriteLine(scooter.VehicleUsageCalculateInternal(22, 33)); // //Access to internal method of parental class.
            //Console.WriteLine(scooter.VinNumberProtect); // Inaccessible protected property.

            Console.WriteLine(scooter.VinNumber);          //Access to _vinNumberProtect field of Motorcycle class.

            Console.WriteLine(scooter.VinNumberPrivate);   //Access to _vinNumber private protected of Motorcycle class.
            Smalltruck smalltruck = new Smalltruck();
            Console.WriteLine(smalltruck.VinNumberPrivateProtect); ///Access to _vinNumber private protected of Truck class.
        }
    }
}
