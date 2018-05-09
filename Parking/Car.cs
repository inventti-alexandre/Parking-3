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
        public int Balance { get; set; }
        /// <summary>
        /// Type of car
        /// </summary>
        public CarType CarType { get; }
        /// <summary>
        /// An event raising when <see cref="Parking"/> debits money from <see cref="Car"/> account
        /// </summary>
        private event EventHandler Timeout;
        /// <summary>
        /// Method-wrapper for <see cref="Car.Timeout"/> event
        /// </summary>
        public void OnTimeout()
        {
            Timeout?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// Initialize new instance of <see cref="Car"/>
        /// </summary>
        /// <param name="balance">Initial amount of money.</param>
        /// <param name="type"><see cref="CarType"/> type of car.</param>
        public Car(int balance, CarType type)
        {
            Id = Guid.NewGuid().ToString();
            CarType = type;
        }
    }
}
