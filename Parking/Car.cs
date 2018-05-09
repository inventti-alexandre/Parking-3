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
        /// Unique identifier of car
        /// </summary>
        public readonly string Id;
        /// <summary>
        /// Car's balance
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
        public Car(double balance, CarType type)
        {
            Id = Guid.NewGuid().ToString();
            Balance = balance;
            CarType = type;
        }
    }
}
