using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public enum CarType
    {
        Passenger,
        Truck,
        Bus,
        Motorcycle
    }
    public class Car
    {
        public readonly string Id;
        public int Balance { get; set; }
        public CarType CarType { get; }
        public Car(int balance, CarType type)
        {
            Id = Guid.NewGuid().ToString();
            CarType = type;
        }
    }
}
