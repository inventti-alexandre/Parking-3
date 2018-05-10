using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking
{
    public class Parking
    {
        private Timer timer;

        private static Lazy<Parking> instance = new Lazy<Parking>(() => new Parking()); 
        public List<Car> CarsList { get; }
        public List<Transaction> TransactionsList { get; }
        public double EarnedMoney { get; set; }
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
             
        private Parking()
        {
            timer = new Timer(changeParkingState, new object(), 0, Settings.Timeout);
            CarsList = new List<Car>();
            TransactionsList = new List<Transaction>();
        }

        public static Parking GetInstanse()
        {
            return instance.Value;
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format("Input '{0}' argumet was null", nameof(car)));
            }
            if (!CarsList.Contains(car,new CarEqualityComparer()))
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

            if(CarsList.Contains(car,new CarEqualityComparer()))
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

        private async void changeParkingState(object obj)
        {
            await Task.Run(() => {
                CarsList.ForEach(car =>
                {
                    double requiredMoney;
                    if(Settings.PriceSet.TryGetValue(car.CarType, out requiredMoney))
                    {
                        double spentMoney = car.Balance >= requiredMoney ? requiredMoney : requiredMoney * Settings.Fine;
                        car.Balance -= spentMoney;
                        this.EarnedMoney += spentMoney;
                        Transaction tr = new Transaction(car.Id, spentMoney);
                        TransactionsList.Add(tr);
                    }
                    
                });
            });
        }
    }
}
