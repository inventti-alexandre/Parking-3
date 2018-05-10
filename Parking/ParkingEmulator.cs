using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingEmulator
    {
        private Timer stateTimer;
        private Timer logTimer;
        private List<Car> carsList;
        private List<Transaction> transactionsList;
        private static Lazy<ParkingEmulator> instance = new Lazy<ParkingEmulator>(() => new ParkingEmulator());
        private string fileName= "Transactions.log";

        public double EarnedMoney { get; set; }
        public int FreePlaces
        {
            get
            {
                return Settings.ParkingSpace - carsList.Count;
            }
        }
        public int EngagedPlaces
        {
            get
            {
                return carsList.Count;
            }
        }
        private string filePath
        {
            get
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(directory, fileName);
            }
        }     
        private ParkingEmulator()
        {
            stateTimer = new Timer(changeParkingState, new object(), 0, Settings.Timeout);
            logTimer = new Timer(logTransactions, new object(), 0, 10000);
            carsList = new List<Car>();
            transactionsList = new List<Transaction>();
        }

        public static ParkingEmulator GetInstanse()
        {
            return instance.Value;
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format("Input '{0}' argumet was null", nameof(car)));
            }
            if (!carsList.Contains(car,new CarEqualityComparer()))
            {
                carsList.Add(car);
            }
            else
            {
                throw new ArgumentException(String.Format("The parking already contains a car with '{0}' description",car.Id));
            }
        }

        public void RemoveCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format("Input '{0}' argument was null", nameof(car)));
            }

            if(carsList.Contains(car,new CarEqualityComparer()))
            {
                if (car.Balance > 0)
                    carsList.Remove(car);
                else
                    throw new InvalidOperationException("This car's balance is less than 0. Please, top up an account");
            }
            else
            {
                throw new ArgumentException("There no such car on the parking!");
            }

        }
        public async string GetTransactionsLog()
        {
            return await Task.Run(() =>
            {
                using (FileStream fs = new File.Open(filePath, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {

                }
                return String.Empty;
            });
                    
        }

        private async void logTransactions(object obj)
        {
            await Task.Run(() =>
            {
                
                using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate | FileMode.Append))
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    double sum;
                    lock (transactionsList)
                    {
                        sum = transactionsList.Sum(tr => tr.SpentMoney);
                        transactionsList.Clear();
                    }
                    string strToLog = String.Format("{0}{1}{0}{2}{0}{3}",
                        Environment.NewLine,
                        DateTime.Now.ToShortDateString(),
                        DateTime.Now.ToShortTimeString(),
                        sum);
                    sw.WriteLine(strToLog);
                }
            });
        }

        private async void changeParkingState(object obj)
        {
            await Task.Run(() => {
                carsList.ForEach(car =>
                {
                    double requiredMoney;
                    if(Settings.PriceSet.TryGetValue(car.CarType, out requiredMoney))
                    {
                        double spentMoney = car.Balance >= requiredMoney ? requiredMoney : requiredMoney * Settings.Fine;
                        car.Balance -= spentMoney;
                        this.EarnedMoney += spentMoney;
                        Transaction tr = new Transaction(car.Id, spentMoney);
                        transactionsList.Add(tr);
                    }
                    
                });
            });
        }
    }
}
