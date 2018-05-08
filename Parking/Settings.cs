using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Parking
{
    public static class Settings
    {
        public static int Timeout { get; }
        public static Dictionary<CarType, int> PriceSet { get; } = new Dictionary<CarType, int>
        {
            {CarType.Truck,5 },
            {CarType.Passenger,3 },
            {CarType.Bus,2 },
            {CarType.Motorcycle,1 }
        };
        public static int ParkingSpace { get; }
        public static double Fine { get; }
        static Settings()
        {

        }
    }
}
