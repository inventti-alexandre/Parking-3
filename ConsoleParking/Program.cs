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
            t = new Timer(doSmth,new object(),5000,5000);
            Car c = new Car("Blue car", 50, CarType.Bus);
            Car b = new Car("Green car", 50, CarType.Motorcycle);
            p.AddCar(c);
            p.AddCar(b);
            Console.Read();
        }

        static void doSmth(object obj)
        {
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
