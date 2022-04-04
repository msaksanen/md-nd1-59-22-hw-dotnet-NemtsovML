using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW._07.Task7.AssemblyOne
{
    class Motorcycle
    {
        internal const ushort MaxMotoSpeedInternal = 300;
        const ushort MaxSpeedPrivate = 300;
        protected string _vinNumber = "twet43464367-43428f-ufnuntyfu333";
        protected internal string _vinNumberProtect = "twet43464367-43428f-ufnuntyfu333";
        private int _odometer = 20_000;
        internal int _distance;
        public DateTime _dateOfBuy;

        internal int VehicleUsageCalculateInternal(int a, int b)
        {
            return a * b * _distance;
        }

        public int Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                _distance = value;
            }
        }

        public int OdometerPublic
        {
            get
            {
                return _odometer;
            }
            set
            {
                _odometer = value;
            }
        }

        internal string VinNumberInternal
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }
        private string VinNumberPrivate
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }

        protected string VinNumberProtect
        {
            get
            {
                return _vinNumberProtect;
            }
            set
            {
                _vinNumberProtect = value;
            }
        }


        private protected string VinNumberPrivateProtect
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }
    }
    class Scooter : Motorcycle
    {
        internal const byte MaxScootEngineVol = 50;
        int MaxScootSpeed = 50;
        public string VinNumber
        {
            get
            {
                return _vinNumberProtect;
            }
            set
            {
                _vinNumberProtect = value;
            }
        }

        public string VinNumberPrivate
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }

    }


    public class Truck
    {
        const ushort MaxTruckSpeedInternal = 140;
        const ushort MaxSpeedPrivate = 140;
        private protected string _vinNumber = "twet43464fff367-43428f-ufnuntyfu333";
        private int _odometer = 20_000;
        internal int _distance;
        internal protected int _distanceIntProt;
        public DateTime _dateOfBuy;

        internal int VehicleUsageCalculateInternal(int a, int b)
        {
            return a * b * _distance;
        }

        public int Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                _distance = value;
            }
        }

        public int OdometerPublic
        {
            get
            {
                return _odometer;
            }
            set
            {
                _odometer = value;
            }
        }

        internal string VinNumberInternal
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }
        private string VinNumberPrivate
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }
    }
    class Smalltruck : Truck
    {
        public string VinNumberPrivateProtect
        {
            get
            {
                return _vinNumber;
            }
            set
            {
                _vinNumber = value;
            }
        }
    }

}
