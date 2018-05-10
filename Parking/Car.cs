using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    /// <summary>
    /// Reprsents actual types of cars
    /// </summary>
    public enum CarType
    {
        Passenger,
        Truck,
        Bus,
        Motorcycle
    }
    /// <summary>
    /// Represents some car.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Car identifier
        /// </summary>
        public readonly string Id;
        /// <summary>
        /// Car balance
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Type of car
        /// </summary>
        public CarType CarType { get; }
        /// <summary>
        /// Initialize new instance of <see cref="Car"/>
        /// </summary>
        /// <param name="balance">Initial amount of money.</param>
        /// <param name="type"><see cref="CarType"/> type of car.</param>
        public Car(string id, double balance, CarType type)
        {
            Id = id;
            Balance = balance;
            CarType = type;
        }
    }

    public class CarEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Car obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
