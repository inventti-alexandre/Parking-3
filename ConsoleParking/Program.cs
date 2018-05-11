using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking;
using System.Threading;

namespace ConsoleParking
{
    class Program
    {
        static ParkingEmulator p = ParkingEmulator.GetInstanse();
        static Timer t;
        static void Main(string[] args)
        {
            ShowBasicMenu();
            var key=Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    DoFirstMenuItemChosen();
                    break;
                case '2':
                    DoSecondMenuItemChosen();
                    break;
                case '3':
                    DoThirdMenuItemChosen();
                    break;
                case '4':
                    DoFourthMenuItemChosen();
                    break;
                case '5':
                    DoFifthMenuItemChosen();
                    break;



            }
        }
        static void DoSixthMenuItemChosen()
        {
            Console.WriteLine(String.Format("Transactions during the last minute:{0}{1}",Environment.NewLine,p. );
        }
        static void DoFifthMenuItemChosen()
        {
            Console.WriteLine(String.Format("All earned money: {0:D2}",p.EarnedMoney);
        }
        static async void DoFourthMenuItemChosen()
        {
            Console.WriteLine(String.Format("Earned money during the last minute: {0:D2}", await p.GetLastEarnedMoney()));
        }
        static void DoThirdMenuItemChosen()
        {
            if (p.CarsList.Count != 0)
            {
                int carNumber;
                do
                {
                    Console.WriteLine("Choose a car to top up it's account by typing number printed near wished car and pressing 'Enter'!");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < p.CarsList.Count; i++)
                    {
                        sb.AppendFormat("{0}.{1}", i, p.CarsList[i]);
                        sb.AppendLine();
                    }
                    Console.WriteLine(sb.ToString());
                }
                while (!Int32.TryParse(Console.ReadLine(), out carNumber) || carNumber >= p.CarsList.Count);

                Car car = p.CarsList[carNumber - 1];

                Console.WriteLine(String.Format("Current balance is: {0:D2}",car.Balance));
                double money;

                do
                {
                    Console.WriteLine("Type sum to be added to balance and press 'Enter'");
                }
                while (!Double.TryParse(Console.ReadLine(), out money));

                car.Balance += money;

                Console.WriteLine("Operation completed successfully!");
                Console.WriteLine(String.Format("Current balance is: {0:D2}", car.Balance));
            }
            else
            {
                Console.WriteLine("There are no cars in parking!");
            }
        }
        static void DoSecondMenuItemChosen()
        {
            if (p.CarsList.Count != 0)
            {
                int carNumber;
                do
                {
                    Console.WriteLine("Choose a car to remove from parking by typing it's number and pressing 'Enter'!");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < p.CarsList.Count; i++)
                    {
                        sb.AppendFormat("{0}.{1}", i, p.CarsList[i]);
                        sb.AppendLine();
                    }
                    Console.WriteLine(sb.ToString());
                }
                while (!Int32.TryParse(Console.ReadLine(), out carNumber) || carNumber >= p.CarsList.Count);

                Car car = p.CarsList[carNumber - 1];
                try
                {
                    p.RemoveCar(car);
                    Console.WriteLine(String.Format("Car '{0}' has successfully been removed from parking",car.Id));
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Nothing to remove from parking!");
            }
        }
        static void DoFirstMenuItemChosen()
        {
            Console.Clear();
            Console.WriteLine("Type a description of a car and press 'Enter'");
            string carId = Console.ReadLine();

            double balance;
            do
            {
                Console.WriteLine("Type inital balance of a car");
            }
            while (!Double.TryParse(Console.ReadLine(), out balance));
            
            CarType type;
            Console.WriteLine("Choose a type of a car:\n");
            Console.WriteLine("1.Truck");
            Console.WriteLine("2.Passenger");
            Console.WriteLine("3.Bus");
            Console.WriteLine("4.Motorcycle");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    type = CarType.Truck;
                    break;
                case '2':
                    type = CarType.Passenger;
                    break;
                case '3':
                    type = CarType.Bus;
                    break;
                case '4':
                    type = CarType.Motorcycle;
                    break;
                default:
                    Console.WriteLine("You haven't chosen any type. Default type is passenger.");
                    type = CarType.Passenger;
                    break;
            }
            Car car = new Car(carId, balance, type);
            try
            {
                p.AddCar(car);
                Console.WriteLine(String.Format("Car {0} has succesfully been added to parking!",car.Id));
                Console.Beep();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ShowBasicMenu()
        {
            Console.WriteLine("Hi! Here is some demo parking. Use numbers on your keyboard for surfing.\n\n");
            Console.WriteLine("1.Add a car");
            Console.WriteLine("2.Remove a car");
            Console.WriteLine("3.Top up an account");
            Console.WriteLine("4.Show earned money during the last minute");
            Console.WriteLine("5.Show all earned money");
            Console.WriteLine("6.Show transactions during the last minute");
            Console.WriteLine("7.Show all transactions");
            Console.WriteLine("8.Show amount of free places");
            Console.WriteLine("9.Show amount of engaged places");
            Console.WriteLine("0.Clear console");
            Console.WriteLine("x.Exit");
        }
        static void doSmth(object obj)
        {
            t = new Timer(doSmth, new object(), 5000, 5000);
            Car c = new Car("Blue car", 50, CarType.Bus);
            Car b = new Car("Green car", 50, CarType.Motorcycle);
            p.AddCar(c);
            p.AddCar(b);
            Console.Read();
            try
            {

                //Console.WriteLine("Last money: "+p.GetLastEarnedMoney().GetAwaiter().GetResult());
                Console.WriteLine("Free places: " + p.FreePlaces.ToString());
                Console.WriteLine("Engaged places: " + p.EngagedPlaces.ToString());
                Console.WriteLine("Log: " + p.GetTransactionsLog().GetAwaiter().GetResult());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: \n"+e.Message);
            }
        }


    }
}
