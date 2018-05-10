using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking;

namespace ConsoleParking
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingEmulator p = ParkingEmulator.GetInstanse();
            Car c = new Car("Blue car", 50, CarType.Bus);
            Car b = new Car("Green car", 50, CarType.Motorcycle);
            try
            {
                p.AddCar(c);
                p.AddCar(b);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
