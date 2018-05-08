using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Settings
    {
        public int Timeout { get; }
        public Dictionary<CarType, int> PriceSet { get; } = new Dictionary<CarType, int>
        {
            {CarType.Truck,5 },
            {CarType.Passenger,3 },
            {CarType.Bus,2 },
            {CarType.Motorcycle,1 }
        };
        public int ParkingSpace { get; }
        public double Fine { get; }
        
    }
}
