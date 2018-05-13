using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking;

namespace ConsoleParking
{
    public class ParkingMenu
    {
        private ParkingEmulator parking;
        public ParkingMenu(ParkingEmulator parking)
        {
            this.parking = parking;
        }

        public void Run()
        {
            do
            {
                ShowBasicMenu();
                var key = Console.ReadKey();
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
                    case '6':
                        DoSixthMenuItemChosen();
                        break;
                    case '7':
                        DoSeventhMenuItemChosen();
                        break;
                    case '8':
                        DoEighthMenuItemChosen();
                        break;
                    case '9':
                        DoNinethMenuItemChosen();
                        break;
                    case '0':
                        DoZerothMenuItemChosen();
                        break;
                    case 'x':
                        DoXMenuitemChosen();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nothing correct chosen!");
                        Console.ReadLine();
                        break;
                }
            } while (true);

        }
        private void DoXMenuitemChosen()
        {
            Console.WriteLine();
            Environment.Exit(0);
        }
        private static void DoZerothMenuItemChosen()
        {
            Console.Clear();
        }
        private void DoNinethMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine("Amount of engaged places: {0}", parking.EngagedPlaces);
            Console.ReadLine();
        }
        private void DoEighthMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine("Amount of free places: {0}", parking.FreePlaces);
            Console.ReadLine();
        }
        private async void DoSeventhMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("All transactions: {0}{1}", Environment.NewLine, await parking.GetTransactionsLog()));
            Console.ReadLine();
        }
        private void DoSixthMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("Transactions during the last minute:{0}{1}", Environment.NewLine, parking.GetLastTransactions()));
            Console.ReadLine();
        }
        private void DoFifthMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("All earned money: {0:C2}!", parking.EarnedMoney));
            Console.ReadLine();
        }
        private async void DoFourthMenuItemChosen()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("Earned money during the last minute: {0:C2}", await parking.GetLastEarnedMoney()));
            Console.ReadLine();
        }
        private void DoThirdMenuItemChosen()
        {
            Console.WriteLine();
            if (parking.CarsList.Count != 0)
            {
                int carNumber;
                do
                {
                    Console.WriteLine("Choose a car to top up it's account by typing number printed near wished car and pressing 'Enter'!");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < parking.CarsList.Count; i++)
                    {
                        sb.AppendFormat("{0}.{1}", i, parking.CarsList[i].Id);
                        sb.AppendLine();
                    }
                    Console.WriteLine(sb.ToString());
                }
                while (!Int32.TryParse(Console.ReadLine(), out carNumber) || carNumber >= parking.CarsList.Count);

                Car car = parking.CarsList[carNumber];

                Console.WriteLine(String.Format("Current balance is: {0:C2}", car.Balance));
                double money;

                do
                {
                    Console.WriteLine("Type sum to be added to balance and press 'Enter'");
                }
                while (!Double.TryParse(Console.ReadLine(), out money) || money <=0);

                car.Balance += money;

                Console.WriteLine("Operation completed successfully!");
                Console.WriteLine(String.Format("Current balance is: {0:C2}", car.Balance));
                Console.Beep();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There are no cars in parking!");
                Console.ReadLine();
            }
        }
        private void DoSecondMenuItemChosen()
        {
            Console.WriteLine();
            if (parking.CarsList.Count != 0)
            {
                int carNumber;
                do
                {
                    Console.WriteLine("Choose a car to remove from parking by typing it's number and pressing 'Enter'!");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < parking.CarsList.Count; i++)
                    {
                        sb.AppendFormat("{0}.{1}", i, parking.CarsList[i].Id);
                        sb.AppendLine();
                    }
                    Console.WriteLine(sb.ToString());
                }
                while (!Int32.TryParse(Console.ReadLine(), out carNumber) || carNumber >= parking.CarsList.Count);

                Car car = parking.CarsList[carNumber];
                try
                {
                    parking.RemoveCar(car);
                    Console.WriteLine(String.Format("Car '{0}' has successfully been removed from parking", car.Id));
                    Console.Beep();
                    Console.ReadLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Nothing to remove from parking!");
                Console.ReadLine();
            }
        }
        private void DoFirstMenuItemChosen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Type a description of a car and press 'Enter'");
            string carId = Console.ReadLine();

            double balance;
            do
            {
                Console.WriteLine("Type inital balance of a car");
            }
            while (!Double.TryParse(Console.ReadLine(), out balance) || balance <= 0);

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
                parking.AddCar(car);
                Console.WriteLine(String.Format("Car '{0}' has succesfully been added to parking!", car.Id));
                Console.Beep();
                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void ShowBasicMenu()
        {
            Console.Clear();
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
    }
    
}
