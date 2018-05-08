using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parking
    {

        public List<Car> CarsList { get; }
        public List<Transaction> TransactionsList { get; }
        public int EarnedMoney { get; set; }
        public int FreePlaces
        {
            get
            {
                return Settings.ParkingSpace - CarsList.Count;
            }
        }
        public int EngagedPlaces
        {
            get
            {
                return CarsList.Count;
            }
        }
             
        public Parking()
        {
            CarsList = new List<Car>();
            TransactionsList = new List<Transaction>();
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format("Input '{0}' argumet was null", nameof(car)));
            }
            if (!CarsList.Contains(car))
            {
                CarsList.Add(car);
            }
            else
            {
                throw new ArgumentException(String.Format("The parking already contains this car!"));
            }
        }

        public void RemoveCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format("Input '{0}' argument was null", nameof(car)));
            }

            if(CarsList.Contains(car))
            {
                if (car.Balance > 0)
                    CarsList.Remove(car);
                else
                    throw new InvalidOperationException("This car's balance is less than 0. Please, top up an account");
            }
            else
            {
                throw new ArgumentException("There no such car on the parking!");
            }

        }
        public void ShowTransactionsLog()
        {
            throw new NotImplementedException();       
        }
    }
}
